# Testing
FROM node:13.12.0-stretch AS build
WORKDIR /usr/src/app
COPY package.json ./
RUN npm install
COPY . .
RUN npm run build

### STAGE 2: Run ###
FROM arm32v7/nginx:stable-alpine
EXPOSE 80
RUN rm /etc/nginx/conf.d/default.conf
COPY --from=build /usr/src/app/nginx_config/default.conf /etc/nginx/conf.d/default.conf
COPY --from=build /usr/src/app/dist/RaspberryDashboard-Frontend /usr/share/nginx/html
