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
}

const showAll = () => {
  const hiddenProducts = Array.from(elements.getHiddenProducts());
  hiddenProducts.forEach((p) => p.classList.remove("hidden"));
}

const hideMasculine = () => {
  showAll();
  const masculineProducts = Array.from(elements.getMasculineProducts());
  masculineProducts.forEach((p) => p.classList.add("hidden"));
}

const hideFeminine = () => {
  showAll();
  const feminineProducts = Array.from(elements.getFeminineProducts());
  feminineProducts.forEach((p) => p.classList.add("hidden"));
}

export const initializeFilters = () => {
  elements.getShowAll().addEventListener("click", showAll);
  elements.getShowMasculine().addEventListener("click", hideFeminine);
  elements.getShowFeminine().addEventListener("click", hideMasculine);
}