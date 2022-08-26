# EDC 2022 conference, Radix application example on dotnet core

Install [Docker](https://docs.docker.com/get-docker/) and [dotnet core](https://docs.microsoft.com/en-us/dotnet/core/install/)

### Prepare the app
* Create the application code
* Create `Dockerfile` and `radixconfig.yaml`
* Register an Radix application in the Radix console
* Deploy the application
* Create a cloud database. E.g. Azure Sql database 
* Set the `CONNECTION_STRING` secret for the application component for the created database
* Initiate the migration for the application code
  * On the local PC/Mac:
    * Install the [`dotnet-ef` tool](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)
    * In a terminal navigate to the app folder, run the command `dotnet ef migrations add InitialCreate`
  * In the docker container:
    * Run the container with .net core SDK `docker run -it -v /<path-to-project>/app:/var/app -i mcr.microsoft.com/dotnet/sdk:6.0`
    * in the container's shell:
      * Install the [`dotnet-ef` tool](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)
      * Navigate to the mounted folder `/var/app`, run the command `dotnet ef migrations add InitialCreate`
* In the project - create the folder `tekton` and create files `pipeline.yaml` and `migration-task.yaml`
* Commit and push the changes to the GitHub - Radix should run the pipeline job with sub-pipeline. 
  * This sub-pipeline should run initial database migration with the command `dotnet ef database update`
  * If migration fails - the sub-pipeline fails, the Radix pipeline job and further deployment is not proceeded.
* 

### Run the application locally
* Run the application locally and open in a browser a link [http://localhost:8000](http://localhost:8000).

### Run the application in the Docker container
* Run `docker-compose up` (or `docker-compose up --build` to rebuild existing container layers).
* Open in a browser a link [http://localhost:8000](http://localhost:8000/).
* Run `docker-compose down` to remove docker containers after its use.
