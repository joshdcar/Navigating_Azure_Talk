#!/bin/bash

resourceGroup=navigating-azure-rg
gitrepo=https://github.com/Azure-Samples/php-docs-hello-world
region=eastus
webappname=navigating-azure-$RANDOM
aspName=$webappname-asp
tier=B1

# Create a resource group.
az group create --location $region --name $resourceGroup

# Create an App Service plan 
az appservice plan create --name $webappname-asp --resource-group $resourceGroup --sku $tier

# Create a web app.
az webapp create --name $webappname --resource-group $resourceGroup --plan $aspName 

# Deploy code from a public GitHub repository. 
az webapp deployment source config --name $webappname --resource-group $resourceGroup \
--repo-url $gitrepo --branch master --manual-integration

# Copy the result of the following command into a browser to see the web app.
echo http://$webappname.azurewebsites.net

# Hybrid Connection
az relay hyco create --resource-group $resourceGroup --namespace-name $rlnamespace --requires-client- 
authorization true --name $hcname --user-metadata $usermetadata

az relay hyco authorization-rule create --resource-group myresourcegroup --namespace-name mynamespace --hybrid-connection-name myhyco --name myauthorule --rights Send Listen

