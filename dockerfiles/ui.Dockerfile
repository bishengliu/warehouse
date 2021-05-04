# Build container
FROM node:10 as builder

ARG PROJECT_DIR=./warehouse-ui

WORKDIR /app

COPY ${PROJECT_DIR}/package.json ./package.json
COPY ${PROJECT_DIR}/package-lock.json ./package-lock.json
COPY ${PROJECT_DIR}/src/assets/nginx.conf .

RUN npm ci

COPY ${PROJECT_DIR}/tsconfig.json ./tsconfig.json
COPY ${PROJECT_DIR}//tsconfig.app.json ./tsconfig.app.json
COPY ${PROJECT_DIR}/tslint.json ./tslint.json
COPY ${PROJECT_DIR}/angular.json ./angular.json

COPY ${PROJECT_DIR}/src ./src

RUN npm run build

# Run-time container
FROM nginx

# copy application
COPY --from=builder /app/dist/warehouse-ui /usr/share/nginx/html

# copy ngnix.conf
COPY --from=builder /app/nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80