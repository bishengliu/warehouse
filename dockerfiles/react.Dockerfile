# Build container
FROM node:10 as builder

ARG PROJECT_DIR=./warehouse-react

WORKDIR /app

COPY ${PROJECT_DIR}/package.json ./package.json
COPY ${PROJECT_DIR}/package-lock.json ./package-lock.json
COPY ${PROJECT_DIR}/src/assets/nginx.conf .

RUN npm ci
RUN npm install react-scripts -g

COPY ${PROJECT_DIR} .

RUN npm run build

# Run-time container
FROM nginx

# copy application
COPY --from=builder /app/build /usr/share/nginx/html

# copy ngnix.conf
COPY --from=builder /app/nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80