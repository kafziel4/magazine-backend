import { initializeCart, renderCart, updatePrice } from "./src/cart-menu";
import { initializeFilters } from "./src/catalog-filter";
import { renderCatalog } from "./src/product-card";

renderCatalog();
initializeCart();
renderCart();
updatePrice();
initializeFilters();