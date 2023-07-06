# .NET API Template with GitHub Actions workflow

* A simple .NET API
  * Created using ``dotnet new webapi``
  * [Dockerized](https://github.com/rezabmirzaei/dotnet-api-template/blob/main/Dockerfile)
* CI/CD pipeline (GitHub Actions) to build image and upload to Docker Hub
  * Workflow created using GitHub Action's default template for creating a Docker container, then expanded

## Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/en-us/download) (.NET 7.0 used here as of July 2023)
* [Docker Desktop](https://docs.docker.com/desktop/install/windows-install/) and a [Docker Hub](https://hub.docker.com/) account

## Test locally

* Clone/fork project
* In root folder, open terminal and run:
  * ``dotnet run``
  * Check http://localhost:5010/weatherforecast

To build a Docker-image, in root folder, open terminal and run:
* ``docker build -t <YOUR_DOCKER_USERNAME>/dotnet-api-template .``

To run image, open terminal and run:
* ``docker run --name dotnet-api-template -dp 5010:80 <YOUR_DOCKER_USERNAME>/dotnet-api-template``
* Check http://localhost:5010/weatherforecast

## CI/CD with GitHub Actions

The workflow is defined in [docker-image.yml](https://github.com/rezabmirzaei/dotnet-api-template/blob/main/.github/workflows/docker-image.yml). It will run automatically on every push to this branch.

### Setup

In you Docker Hub account, create an [access token](https://docs.docker.com/docker-hub/access-tokens/). Remember the value! You will need it when configuring the GitHub Actions workflow.

In GitHub, in the repository for your API, under _Settings > Secrets and variables > Actions_; create two new secrets:
* ``DOCKERHUB_USERNAME`` containing your Docker Hub username
* ``DOCKERHUB_TOKEN`` containing the access token you created for you Docker Hub account

These values will be used in the automated workflow to build and push your image to ``<DOCKERHUB_USERNAME>/dotnet-api-tamplate:latest``

### Test build/push to Docker Hub

* Make a change in the API and push the changes to your repository.
* In GitHub, in your repository for this project, monitor the build process under the _Actions_ tab.
* When done, check your Docker Hub account under _Repositories_ and you should see a new image of this API.