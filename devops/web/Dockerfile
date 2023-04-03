FROM node:18-alpine 

WORKDIR /app

RUN apk add --no-cache git

RUN git clone https://github.com/gnuvinicius/mstar-supply-challenge.git

WORKDIR /app/mstar-supply-challenge/mstarsupplyweb

RUN npm install

RUN npm install -g serve

RUN npm run build

EXPOSE 3000

CMD [ "npx", "serve", "-s", "build" ]