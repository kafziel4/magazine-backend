FROM node:18-alpine as build

WORKDIR /app
EXPOSE 80
COPY ["package.json", "."]
RUN npm i
COPY . .
ARG API_BASE_URL
ARG CUSTOMER_ID
ENV VITE_CUSTOMER_ID=$CUSTOMER_ID
ENV VITE_API_BASE_URL=$API_BASE_URL
RUN npm run build

FROM nginx:1-alpine
COPY --from=build /app/dist /usr/share/nginx/html