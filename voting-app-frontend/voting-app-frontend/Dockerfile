# Etap 1: Budowanie aplikacji Angular
FROM node:14-alpine AS build
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build --prod

FROM nginx:alpine
RUN rm -rf /usr/share/nginx/html/*
COPY --from=build /app/dist/voting-app-frontend /usr/share/nginx/html
COPY nginx.conf /etc/nginx/nginx.conf
ENV PORT 80
EXPOSE $PORT
CMD ["sh", "-c", "envsubst '$PORT' < /etc/nginx/nginx.conf > /etc/nginx/nginx-processed.conf && nginx -g 'daemon off;' -c /etc/nginx/nginx-processed.conf"]