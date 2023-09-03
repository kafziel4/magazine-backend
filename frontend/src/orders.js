import { drawProductCard, readFromLocalStorage } from "./utils";

const createOrderHistory = (order) => {
  const orderElement =
    `<p class="text-xl text-bold my-4">
      ${new Date(order.date)
        .toLocaleDateString("pt-BR", { hour: "2-digit", minute: "2-digit" })}
    </p>
    <section
      id="order-container-${order.date}"
      class="bg-slate-300 p-3 rounded-md"
    >
    </section>`;

    const main = document.getElementsByTagName("main")[0];
    main.innerHTML += orderElement;

    order.orderItems.forEach((p) => 
      drawProductCard(p.id, `order-container-${order.date}`, p.quantity));
}

const renderOrderHistory = () => {
  const history = readFromLocalStorage("history");
  history.forEach((o) => createOrderHistory(o));
}

renderOrderHistory();