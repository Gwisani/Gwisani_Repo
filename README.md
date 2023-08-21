# Gwisani_Repo
NSAssigmentapi(THIS INSTRUCTION IS ALSO ON THE POWERPOINT PRESENTATIONS)

Deploy API to docker

Deploy instruction
Port 8080(Change this port if not available)
URL: http://localhost:8080/swagger/index.html 

1. Open visual studio, search for terminal at the search bar, ensure NS_AssigmentAPI is selected

Docker URL: http://localhost:8080/swagger/index.html 
![image](https://github.com/Gwisani/Gwisani_Repo/assets/127345901/11e0d714-dfa7-4506-b0d6-ef84f65d31b9)


2. Run the docker cmd line below to build and deploy the API
   docker build -t gwisanidocker:v1 -f NS_Assignment/Dockerfile .
![image](https://github.com/Gwisani/Gwisani_Repo/assets/127345901/6ab605cc-f0e2-4b9d-b96c-b9805f7e9cdc)


3. After this is done building, run the command below to start the api, and ensure the url is running before running the site.
   cmd line: docker run -it --rm -p 8080:80 gwisanidocker:v1
![image](https://github.com/Gwisani/Gwisani_Repo/assets/127345901/e63ee5a1-2559-4fd9-8487-c6d7fb336589)


This is how the api should look like when running through swagger, using url http://localhost:8080/swagger/index.html 
![image](https://github.com/Gwisani/Gwisani_Repo/assets/127345901/bdd7313b-7d7c-410a-97a3-874f775c0333)


To run the website, select the NS_Assignemnt.Sites and press debug to run
![image](https://github.com/Gwisani/Gwisani_Repo/assets/127345901/fa37d08b-eaf3-454d-bd3b-89ac44d4a063)


if you changed the docker listening port, open the index.cshtml.cs code behind and enter the new one on the base url variable as shown below
![image](https://github.com/Gwisani/Gwisani_Repo/assets/127345901/973f01bd-f203-41ed-8223-d5c257543e08)

run the project and it will open with this URL: https://localhost:7190/ and page will be like this

![image](https://github.com/Gwisani/Gwisani_Repo/assets/127345901/2a3e2607-33d5-4f15-b7c2-3d0fa0b19580)



