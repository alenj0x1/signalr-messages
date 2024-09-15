FROM node:20-alpine
EXPOSE 3000

WORKDIR /app/client

COPY . .

RUN npm install -g serve

CMD ["serve", "/app/client/"]