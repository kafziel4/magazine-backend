import { getOrders } from "./http-client";
import { drawItemCard } from "./utils";

const createOrderHistory = (order) => {
  const orderElement =
    `<p class="text-xl text-bold my-4">
      ${new Date(order.date)
        .toLocaleDateString("pt-BR", { hour: "2-digit", minute: "2-digit" })}
    </p>
    <section
      id="order-container-${order.id}"
      class="bg-slate-300 p-3 rounded-md"
    >
    </section>`;

    const main = document.getElementsByTagName("main")[0];
    main.innerHTML += orderElement;

    order.items.forEach((i) => 
      drawItemCard(i, `order-container-${order.id}`));
}

const renderOrderHistory = async () => {
  const orders = await getOrders();
  orders.forEach((o) => createOrderHistory(o));
}

renderOrderHistory();