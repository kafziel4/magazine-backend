import {
  catalog,
  deleteFromLocalStorage,
  drawProductCard,
  readFromLocalStorage,
  saveToLocalStorage
} from "./utils";

const drawCart = () => {
  const cart = readFromLocalStorage("cart") ?? [];
  cart.forEach((p) => 
    drawProductCard(p.id, "container-checkout-products", p.quantity));
  drawTotalPrice(cart);
}

const drawTotalPrice = (cart) => {
  const total = cart.reduce((acc, product) => 
    acc + catalog.find((p) => p.id === product.id).price * product.quantity,
    0);
  document.getElementById("total-price").innerHTML = `Total: $ ${total}`;
}

const finalizePurchase = (ev) => {
  ev.preventDefault();
  const cart = readFromLocalStorage("cart") ?? [];
  if (cart.length === 0)
    return;

    const order = {
      date: new Date(),
      orderItems: cart
    }
    
    const orderHistory = readFromLocalStorage("history") ?? [];
    saveToLocalStorage("history", [order, ...orderHistory]);
    deleteFromLocalStorage("cart");

    window.location.href = "./orders.html";
}

drawCart();

document.addEventListener("submit", (ev) => finalizePurchase(ev));