import { createOrder, deleteCart, getCart } from "./http-client";
import { customerIdMock, drawItemCard } from "./utils";

var form = document.getElementById("form");

const drawCart = async () => {
  const cart = await getCart();
  if (cart === null)
    return;

  cart.items.forEach((i) => drawItemCard(i, "container-checkout-items"));
  
  document.getElementById("total-price").innerHTML = 
    `Total: $ ${cart.totalPrice}`;
}  

const finalizePurchase = async (ev) => {
  ev.preventDefault();
  
  const cart = await getCart();
  if (cart === null)
    return;
 
  await createOrder({ customerId: customerIdMock });
  await deleteCart();

  window.location.href = "./orders.html";
}

(async () => {
  try {
    await drawCart();
  } catch (e) {
    console.log("An error ocurred while running checkout.");
  }
})();

document.addEventListener("submit", (ev) => finalizePurchase(ev));