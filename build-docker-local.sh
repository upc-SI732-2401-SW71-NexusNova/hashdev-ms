#!/bin/bash

# Build LoadBalancer
docker build -t loadbalancerservice -f LoadBalancer/Dockerfile LoadBalancer
docker run -d --name loadbalancerservice -p 80:80 -p 443:443 \
  -v $(pwd)/LoadBalancer/nginx.conf:/etc/nginx/nginx.conf:ro \
  -v $(pwd)/LoadBalancer/proxy.conf:/etc/nginx/proxy.conf:ro \
  -v $(pwd)/LoadBalancer/ssl/localhost.crt:/etc/ssl/certs/localhost.crt:ro \
  -v $(pwd)/LoadBalancer/ssl/localhost.key:/etc/ssl/certs/localhost.key:ro \
  -v $(pwd)/LoadBalancer/logs/:/var/log/nginx/ \
  loadbalancerservice

# Build ApiGatewayWithOcelot
docker build -t apigatewayocelotservice -f ApigatewayWithOcelot/Dockerfile ApigatewayWithOcelot
docker run -d --name apigatewayocelotservice -p 5000:5000 -p 5001:5001 apigatewayocelotservice

# Build ApiGatewayWithYarp
docker build -t apigatewayyarpservice -f ApigatewayWithYarp/Dockerfile ApigatewayWithYarp
docker run -d --name apigatewayyarpservice -p 6000:6000 -p 6001:6001 apigatewayyarpservice

# Build ConferenceManagerService
docker build -t conferencemanagerservice -f ConferenceManagerService/Dockerfile ConferenceManagerService
docker run -d --name conferencemanagerservice -p 8010:8010 -p 8011:8011 conferencemanagerservice

# Build FeedManagerService
docker build -t feedmanagerservice -f FeedManagerService/Dockerfile FeedManagerService
docker run -d --name feedmanagerservice -p 8020:8020 -p 8021:8021 feedmanagerservice

# Build PaymentManagerService
docker build -t paymentmanagerservice -f PaymentManagerService/Dockerfile PaymentManagerService
docker run -d --name paymentmanagerservice -p 8030:8030 -p 8031:8031 paymentmanagerservice

# Build UserManagerService
docker build -t usermanagerservice -f UserManagerService/Dockerfile UserManagerService
docker run -d --name usermanagerservice -p 8040:8040 -p 8041:8041 usermanagerservice

echo "All Docker images have been built and are running successfully."
