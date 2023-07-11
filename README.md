# Assignment for a .NET API Template with GitHub Actions workflow and Docker support

* A simple .NET API
  * Created using `dotnet new webapi`
  * [Dockerized](https://github.com/rezabmirzaei/dotnet-api-template/blob/main/Dockerfile)
* CI/CD pipeline (GitHub Actions) to build image and upload to Docker Hub
  * Workflow created using GitHub Action's default template for creating a Docker container, then expanded

## Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/en-us/download) (.NET 7.0 used here as of July 2023)
* [Docker Desktop](https://docs.docker.com/desktop/install/windows-install/) and a [Docker Hub](https://hub.docker.com/) account

## Assignment Details

This project aims to demonstrate the creation of a .NET API template and the setup of a CI/CD pipeline using GitHub Actions for building and pushing the Docker image to Docker Hub. The project includes a simple `WeatherForecastController` that provides weather forecasts with corresponding advice based on predefined summaries.

The controller includes two endpoints:
* `GET /weatherforecast`: Returns a list of weather forecasts for the next 5 days, each including a date, temperature, summary, and advice.
* `GET /weatherforecast/{daysAhead}`: Returns a weather forecast for a specific day ahead, specified by the `daysAhead` parameter. The forecast includes a date, temperature, summary, and advice.

To test the API locally, follow the instructions provided in the **Test locally** section. You can also build and run the Docker image locally using the instructions provided.

The CI/CD pipeline is defined in the `docker-image.yml` workflow file under `.github/workflows/`. It triggers automatically on every push to the repository. The pipeline performs the following steps:
* Builds the Docker image for the API based on the Dockerfile.
* Tags the Docker image with the `<DOCKERHUB_USERNAME>/dotnet-api-template:latest` format.
* Pushes the Docker image to Docker Hub using the provided access token.

By making changes to the API code and pushing them to the repository, the CI/CD pipeline will be triggered, resulting in the build and push of an updated Docker image to Docker Hub.

## Test locally

* Clone/fork the project.
* In the root folder, open a terminal and run:
  * `dotnet run`
  * Visit http://localhost:5010/weatherforecast

To build a Docker image, open a terminal in the root folder and run:
* `docker build -t <YOUR_DOCKER_USERNAME>/dotnet-api-template .`

To run the image, open a terminal and run:
* `docker run --name dotnet-api-template -dp 5010:80 <YOUR_DOCKER_USERNAME>/dotnet-api-template`
* Visit http://localhost:5010/weatherforecast

## CI/CD with GitHub Actions

The workflow is defined in [docker-image.yml](https://github.com/rezabmirzaei/dotnet-api-template/blob/main/.github/workflows/docker-image.yml). It will run automatically on every push to this branch.

### Setup

In your Docker Hub account, create an [access token](https://docs.docker.com/docker-hub/access-tokens/). Remember the value! You will need it when configuring the GitHub Actions workflow.

In GitHub, in the repository for your API, under _Settings > Secrets and variables > Actions_, create two new secrets:
* `DOCKERHUB_USERNAME` containing your Docker Hub username
* `DOCKERHUB_TOKEN` containing the access token you created for your Docker Hub account

These values will be used in the automated workflow to build and push your image to `<DOCKERHUB_USERNAME>/dotnet-api-template:latest`

### Test build/push to Docker Hub

* Make a change in the API and push the changes to your repository.
* In GitHub, in your repository for this project, monitor the build process under the _Actions_ tab.
* Once the build process completes, check your Docker Hub account under _Repositories_, and you should see a new image of this API.

### Deployment Process

1. Provision an Azure App Service using Bicep.
2. Install the Azure CLI.
3. Write a Bicep template to provision an Azure App Service, including the App Service plan, App Service itself, and any required dependencies. Make sure the App Service you provision can run your containerized API. Tip: Use `linuxFxVersion` and other required settings.
4. Test and ensure the Azure App Service resources defined in the Bicep template deploy correctly to your Azure subscription using the Azure CLI.
5. Create and configure a CI/CD pipeline using GitHub Actions or GitLab CI/CD.
6. Create a GitHub or GitLab repository containing all your code, including the Bicep template.
7. Set up a pipeline to automate the build and publication of your containerized API to Docker Hub. Include necessary steps to build, test, and deploy the infrastructure.
8. Configure the pipeline to deploy a new version of the API every time a new Docker image is built.
9. Use webhooks to notify your web app every time a new image is created of the API to have it redeploy the latest version.


### Relevant Branches and Commit Messages

This repository contains the following relevant branch:
- `dotnet-api-template-said`: The branch where development and changes for the API and deployment are made.

The commit messages associated with this branch are as follows:
- `Added new endpoint to WeatherForecastController`: Added a new endpoint to the `WeatherForecastController` to extend the functionality of the API.
- `Changed the standard Get method to include some advice with each different type of weather`: Updated the standard `Get` method in the `WeatherForecastController` to include advice corresponding to each different type of weather.
- `Add advice to weather forecast and fix dictionary length error`: Added advice to the weather forecast by modifying the `Get` method in the `WeatherForecastController` and fixed the dictionary length error.
- `Added

 IaC`: Added Infrastructure as Code (IaC) using Bicep to provision an Azure App Service for hosting the API.

Feel free to customize the branch names and commit messages to align with your specific requirements and naming conventions.

Let me know if there's anything else I can help you with!
