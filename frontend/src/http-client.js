import axios from "axios";
import { customerIdMock } from "./utils";

const apiBaseUrl = import.meta.env.VITE_API_BASE_URL

export const getCatalog = async (feminine = null) => {
  const response = await axios.get(`${apiBaseUrl}/products`, {
    params: {
      feminine: feminine
    }
  });
  return response.data;
}

export const getCart = async (customerId = customerIdMock) => {
  try {
    const response = await axios.get(`${apiBaseUrl}/cart/${customerId}`);
    return response.data;
  } catch(e) {
    return null;
  }
}

export const upsertCart = async (cart) => {
  const response = await axios.post(`${apiBaseUrl}/cart`, cart)
  return response.data;
}

export const deleteCart = async (customerId = customerIdMock) => {
  await axios.delete(`${apiBaseUrl}/cart/${customerId}`);
}

export const createOrder = async (order) => {
  await axios.post(`${apiBaseUrl}/orders`, order);
}

export const getOrders = async (customerId = customerIdMock) => {
  const response = await axios.get(`${apiBaseUrl}/orders/${customerId}`);
  return response.data;
}