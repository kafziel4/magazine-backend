import { getCart, upsertCart } from "./http-client";
import { customerIdMock } from "./utils";

let cartToSend = {
  customerId: customerIdMock,
  items: [],
}

let cartToDraw = {
  items: []
};

const elements = {
  getCart: () => document.getElementById("cart"),
  getCloseCart: () => document.getElementById("close-cart"),
  getOpenCart: () => document.getElementById("open-cart"),
  getCheckout: () => document.getElementById("checkout"),
  getTotalPrice: () => document.getElementById("total-price"),
  getCartItems: () => document.getElementById("cart-items"),
  getRemoveItem: (productId) => 
    document.getElementById(`remove-item-${productId}`),
  getItemDecrement: (productId) => 
    document.getElementById(`decrement-item-${productId}`),
  getItemQuantity: (productId) => 
    document.getElementById(`quantity-item-${productId}`),
  getItemIncrement: (productId) =>
    document.getElementById(`increment-item-${productId}`),
  createArticle: () => document.createElement("article")
}

const getItemFromCartToSend = (productId) => 
  cartToSend.items?.find((i) => i.productId === productId);

const openCart = () => {
  elements.getCart().classList.remove("right-[-360px]");
  elements.getCart().classList.add("right-[0px]");
}

const closeCart = () => {
  elements.getCart().classList.remove("right-[0px]");
  elements.getCart().classList.add("right-[-360px]");
}

const goToCheckout = () => {
  if (cart.length === 0)
    return;

  window.location.href = "./checkout.html";
}

export const initializeCart = async () => {
  elements.getCloseCart().addEventListener("click", closeCart);
  elements.getOpenCart().addEventListener("click", openCart);
  elements.getCheckout().addEventListener("click", goToCheckout);

  var customerCart = await getCart();
  if (customerCart !== null) {
    cartToDraw = customerCart;
    cartToSend.items = customerCart.items
      .map(({productId, quantity}) => ({productId, quantity}));
  }
}

const removeFromCart = async (productId) => {
  cartToSend.items = cartToSend.items.filter((i) => i.productId != productId);
  cartToDraw = await upsertCart(cartToSend);
  renderCart();
}

const incrementItemQuantity = async (productId) => {
  getItemFromCartToSend(productId).quantity += 1;
  cartToDraw = await upsertCart(cartToSend);
  renderCart();
}

const decrementItemQuantity = async (productId) => {
  if (getItemFromCartToSend(productId).quantity === 1) {
    await removeFromCart(productId);
    return;
  }

  getItemFromCartToSend(productId).quantity -= 1;
  cartToDraw = await upsertCart(cartToSend);
  renderCart();
}

export const renderCart = () => {
  elements.getCartItems().innerHTML = "";
  cartToDraw.items.forEach((i) => drawItemInCart(i.productId));

  (cartToDraw.totalPrice > 0)? 
    elements.getTotalPrice().innerHTML = `Total: $ ${cartToDraw.totalPrice}` :
    elements.getTotalPrice().innerHTML = "";
}

export const addToCart = async (productId) => {
  if (getItemFromCartToSend(productId)) {
    await incrementItemQuantity(productId);
    return;
  }

  cartToSend.items.push({ productId: productId, quantity: 1 });
  cartToDraw = await upsertCart(cartToSend);
  renderCart();
}

const drawItemInCart = (productId) => {
  const item = cartToDraw.items.find((i) => i.productId === productId);
  const itemsContainer = elements.getCartItems();

  const articleElement = elements.createArticle();
  const articleClasses = [
    "flex",
    "bg-slate-100",
    "rounded-lg",
    "p-1",
    "relative"
  ];
  articleElement.classList.add(...articleClasses);
  const itemCard = 
    `<button id="remove-item-${item.productId}" class="absolute top-0 right-2">
      <i
        class="fa-solid fa-circle-xmark text-slate-500 hover:text-slate-800"
      >
      </i>
    </button>
    <img
      src="./assets/img/${item.image}"
      alt="Carrinho: ${item.name}"
      class="h-24 rounded-lg"
    >
    <div class="p-2 flex flex-col justify-between">
      <p class="text-slate-900 text-sm">${item.name}</p>
      <p class="text-slate-400 text-xs">Tamanho: ${item.size}</p>
      <p class="text-green-700 text-lg">$ ${item.price}</p>
    </div>
    <div
      class="flex text-slate-950 items-end absolute bottom-0 right-2 text-lg"
    >
      <button id="decrement-item-${item.productId}" class="ml-2">-</button>
      <p id="quantity-item-${item.productId}" class="ml-2">
        ${item.quantity}
      </p>
      <button id="increment-item-${item.productId}" class="ml-2">+</button>
    </div>`;
    
    articleElement.innerHTML = itemCard;
    itemsContainer.appendChild(articleElement);

    elements.getItemDecrement(item.productId)
      .addEventListener("click", () => decrementItemQuantity(item.productId));

    elements.getItemIncrement(item.productId)
      .addEventListener("click", () => incrementItemQuantity(item.productId));

    elements.getRemoveItem(item.productId)
      .addEventListener("click", () => removeFromCart(item.productId));
}
