export const catalog = [
  {
    id: 1,
    brand: "Zara",
    name: "Camisa Larga com Bolsos",
    size: "M",
    price: 70,
    image: "product-1.jpg",
    feminine: false,
  },
  {
    id: 2,
    brand: "Zara",
    name: "Casaco Reto com Lã",
    size: "M",
    price: 85,
    image: "product-2.jpg",
    feminine: true,
  },
  {
    id: 3,
    brand: "Zara",
    name: "Jaqueta com Efeito Camurça",
    size: "M",
    price: 60,
    image: "product-3.jpg",
    feminine: false,
  },
  {
    id: 4,
    brand: "Zara",
    name: "Sobretudo em Mescla de Lã",
    size: "M",
    price: 160,
    image: "product-4.jpg",
    feminine: false,
  },
  {
    id: 5,
    brand: "Zara",
    name: "Camisa Larga Acolchoada de Veludo Cotelê",
    size: "M",
    price: 110,
    image: "product-5.jpg",
    feminine: false,
  },
  {
    id: 6,
    brand: "Zara",
    name: "Casaco de Lã com Botões",
    size: "M",
    price: 170,
    image: "product-6.jpg",
    feminine: true,
  },
  {
    id: 7,
    brand: "Zara",
    name: "Casaco com Botões",
    size: "M",
    price: 75,
    image: "product-7.jpg",
    feminine: true,
  },
  {
    id: 8,
    brand: "Zara",
    name: "Colete Comprido com Cinto",
    size: "M",
    price: 88,
    image: "product-8.jpg",
    feminine: true,
  },
]

export const saveToLocalStorage = (key, value) => 
  localStorage.setItem(key, JSON.stringify(value));

export const readFromLocalStorage = (key) => 
  JSON.parse(localStorage.getItem(key));

export const deleteFromLocalStorage = (key) =>
  localStorage.removeItem(key);

export const drawProductCard = (productId, containerId, productQuantity) => {
  const product = catalog.find((p) => p.id === productId);
  const productContainer = document.getElementById(containerId);

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

  const productCard = 
    `<img
      src="./assets/img/${product.image}"
      alt="Produto: ${product.name}"
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
      <p id="quantity-product-${product.id} class="ml-2">${productQuantity}</p>
    </div>`;

  articleElement.innerHTML = productCard;
  productContainer.appendChild(articleElement);
}