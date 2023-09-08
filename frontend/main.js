import { initializeCart, renderCart } from "./src/cart-menu";
import { initializeFilters, renderCatalog } from "./src/catalog";

(async () => {
  try {
    await renderCatalog();
    await initializeCart();
    renderCart();
    initializeFilters();
  } catch (e) {
    console.log("An error ocurred while running main.");
  }
})();
