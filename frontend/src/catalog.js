import { addToCart } from "./cart-menu";
import { getCatalog } from "./http-client";

let catalog = [];

const elements = {
  get catalog() { return document.getElementById("product-container"); },
  getHiddenProducts: function() { 
    return this.catalog.getElementsByClassName("hidden"); },
  getMasculineProducts: function() { 
    return this.catalog.getElementsByClassName("masculine"); },
  getFeminineProducts: function() {
    return this.catalog.getElementsByClassName("feminine"); },
  getShowAll: () => document.getElementById("show-all"),
  getShowMasculine: () => document.getElementById("show-masculine"),
  getShowFeminine: () => document.getElementById("show-feminine"),
  getProductContainer: () => document.getElementById("product-container"),
  getAddProduct: (productId) => 
    document.getElementById(`add-product-${productId}`)
}

const loadCatalog = async (feminine = null) =>
  catalog = await getCatalog(feminine);

const showAll = async () => await renderCatalog();

const showMasculine = async () => await renderCatalog(false);

const showFeminine = async () => await renderCatalog(true);

export const initializeFilters = () => {
  elements.getShowAll().addEventListener("click", showAll);
  elements.getShowMasculine().addEventListener("click", showMasculine);
  elements.getShowFeminine().addEventListener("click", showFeminine);
}

export const renderCatalog = async (feminine = null) => {
  elements.getProductContainer().innerHTML = "";
  
  await loadCatalog(feminine);
  
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
          id="add-product-${p.id}" 
          class="bg-slate-950 hover:bg-slate-700 text-slate-200"
        >
          <i class="fa-solid fa-cart-plus"></i>
        </button>
      </div>`;

      elements.getProductContainer().innerHTML += productCard;
  });

  catalog.forEach((p) => {
    elements.getAddProduct(p.id)
      .addEventListener("click", () => addToCart(p.id));
  });
}