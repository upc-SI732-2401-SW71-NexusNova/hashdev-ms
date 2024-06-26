#!/bin/bash

# Build LoadBalancer
docker build -t loadbalancer -f LoadBalancer/Dockerfile LoadBalancer

# Build ApiGatewayWithOcelot
docker build -t apigatewaywithocelot -f ApigatewayWithOcelot/Dockerfile ApigatewayWithOcelot

# Build ApiGatewayWithYarp
docker build -t apigatewaywithyarp -f ApigatewayWithYarp/Dockerfile ApigatewayWithYarp

# Build ConferenceManagerService
docker build -t conferencemanagerservice -f ConferenceManagerService/Dockerfile ConferenceManagerService

# Build FeedManagerService
docker build -t feedmanagerservice -f FeedManagerService/Dockerfile FeedManagerService

# Build PaymentManagerService
docker build -t paymentmanagerservice -f PaymentManagerService/Dockerfile PaymentManagerService

# Build UserManagerService
docker build -t usermanagerservice -f UserManagerService/Dockerfile UserManagerService

echo "All Docker images have been built successfully."
