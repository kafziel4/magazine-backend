import { catalog, readFromLocalStorage, saveToLocalStorage } from "./utils";

let cart = readFromLocalStorage("cart") ?? [];

const elements = {
  getCart: () => document.getElementById("cart"),
  getCloseCart: () => document.getElementById("close-cart"),
  getOpenCart: () => document.getElementById("open-cart"),
  getCheckout: () => document.getElementById("checkout"),
  getTotalPrice: () => document.getElementById("total-price"),
  getCartProducts: () => document.getElementById("cart-products"),
  getRemoveProduct: (productId) => 
    document.getElementById(`remove-product-${productId}`),
  getProductDecrement: (productId) => 
    document.getElementById(`decrement-product-${productId}`),
  getProductQuantity: (productId) => 
    document.getElementById(`quantity-product-${productId}`),
  getProductIncrement: (productId) =>
    document.getElementById(`increment-product-${productId}`),
  createArticle: () => document.createElement("article")
}

const getProductFromCart = (productId) => cart.find((p) => p.id === productId);

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

export const initializeCart = () => {
  elements.getCloseCart().addEventListener("click", closeCart);
  elements.getOpenCart().addEventListener("click", openCart);
  elements.getCheckout().addEventListener("click", goToCheckout);
}

const removeFromCart = (productId) => {
  cart = cart.filter((p) => p.id != productId);
  saveToLocalStorage("cart", cart);
  updatePrice();
  renderCart();
}

const incrementProductQuantity = (productId) => {
  getProductFromCart(productId).quantity += 1;
  saveToLocalStorage("cart", cart)
  updatePrice();
  updateProductQuantity(productId);
}

const decrementProductQuantity = (productId) => {
  if (getProductFromCart(productId).quantity === 1) {
    removeFromCart(productId);
    return;
  }

  getProductFromCart(productId).quantity -= 1;
  saveToLocalStorage("cart", cart);
  updatePrice();
  updateProductQuantity(productId);
}

const updateProductQuantity = (productId) =>
  elements.getProductQuantity(productId).innerText = 
    getProductFromCart(productId).quantity;

export const renderCart = () => {
  elements.getCartProducts().innerHTML = "";
  cart.forEach((p) => drawProductInCart(p.id));
}

export const addToCart = (productId) => {
  if (getProductFromCart(productId)) {
    incrementProductQuantity(productId);
    return;
  }

  cart.push({ id: productId, quantity: 1 });
  saveToLocalStorage("cart", cart);
  drawProductInCart(productId);
  updatePrice();
}

export const updatePrice = () => {
  const total = cart.reduce((acc, product) => 
    acc + catalog.find((p) => p.id === product.id).price * product.quantity,
    0);
  elements.getTotalPrice().innerHTML = `Total: $ ${total}`;
}

const drawProductInCart = (productId) => {
  const product = catalog.find((p) => p.id === productId);
  const productsContainer = elements.getCartProducts();

  const articleElement = elements.createArticle();
  const articleClasses = [
    "flex",
    "bg-slate-100",
    "rounded-lg",
    "p-1",
    "relative"
  ];
  articleElement.classList.add(...articleClasses);
  const productCard = 
    `<button id="remove-product-${product.id}" class="absolute top-0 right-2">
      <i
        class="fa-solid fa-circle-xmark text-slate-500 hover:text-slate-800"
      >
      </i>
    </button>
    <img
      src="./assets/img/${product.image}"
      alt="Carrinho: ${product.name}"
      class="h-24 rounded-lg"
    >
    <div class="p-2 flex flex-col justify-between">
      <p class="text-slate-900 text-sm">${product.name}</p>
      <p class="text-slate-400 text-xs">Tamanho: ${product.size}</p>
      <p class="text-green-700 text-lg">$ ${product.price}</p>
    </div>
    <div
      class="flex text-slate-950 items-end absolute bottom-0 right-2 text-lg"
    >
      <button id="decrement-product-${product.id}" class="ml-2">-</button>
      <p id="quantity-product-${product.id}" class="ml-2">
        ${getProductFromCart(productId).quantity}
      </p>
      <button id="increment-product-${product.id}" class="ml-2">+</button>
    </div>`;
    
    articleElement.innerHTML = productCard;
    productsContainer.appendChild(articleElement);

    elements.getProductDecrement(product.id)
      .addEventListener("click", () => decrementProductQuantity(product.id));

    elements.getProductIncrement(product.id)
      .addEventListener("click", () => incrementProductQuantity(product.id));

    elements.getRemoveProduct(product.id)
      .addEventListener("click", () => removeFromCart(product.id));
}
