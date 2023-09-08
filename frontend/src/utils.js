export const customerIdMock = import.meta.env.VITE_CUSTOMER_ID;

export const drawItemCard = (item, containerId) => {
  const itemContainer = document.getElementById(containerId);

  const articleElement = document.createElement("article");
  const articleClasses = [
    "flex",
    "bg-stone-200",
    "rounded-lg",
    "p-1",
    "relative",
    "mb-2",
    "w-96",
  ];
  articleElement.classList.add(...articleClasses);

  const itemCard = 
    `<img
      src="./assets/img/${item.image}"
      alt="Produto: ${item.name}"
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
      <p id="quantity-product-${item.productId} class="ml-2">
        ${item.quantity}
      </p>
    </div>`;

  articleElement.innerHTML = itemCard;
  itemContainer.appendChild(articleElement);
}