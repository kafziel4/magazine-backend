import { addToCart } from "./cart-menu";
import { catalog } from "./utils";

export const renderCatalog = () => {
  catalog.forEach((p) => {
    const productCard = 
      `<div
        id="product-card-${p.id}"
        class="border-solid w-48 m-2 flex flex-col p-2 justify-between shadow-xl shadow-slate-400 rounded-lg group ${p.feminine ? "feminine" : "masculine"}"
      >
        <img
          src="./assets/img/${p.image}"
          alt="Produto ${p.name} do Magazine Hashtag"
          class="group-hover:scale-110 duration-300 my-3 rounded-lg"
        >
        <p class="text-sm">${p.brand}</p>
        <p class="text-sm">${p.name}</p>
        <p class="text-sm">$ ${p.price}</p>
        <button 
          id="add-${p.id}" 
          class="bg-slate-950 hover:bg-slate-700 text-slate-200"
        >
          <i class="fa-solid fa-cart-plus"></i>
        </button>
      </div>`;

      document.getElementById("product-container").innerHTML += productCard;
  });

  catalog.forEach((p) => {
    document.getElementById(`add-${p.id}`)
      .addEventListener("click", () => addToCart(p.id));
  });
}