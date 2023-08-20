# Gwisani_Repo
NSAssigmentapi(THIS INSTRUCTION IS ALSO ON THE POWERPOINT PRESENTATIONS)

Deploy API to docker

Deploy instruction
Port 8080(Change this port if not available)
URL: http://localhost:8080/swagger/index.html 

1. Open visual studio, search for terminal at the search bar, ensure NS_AssigmentAPI is selected
![image](https://github.com/Gwisani/Gwisani_Repo/assets/127345901/be4603c6-4721-4ff5-a88b-745e5ce8d1ad)

![image](https://github.com/Gwisani/Gwisani_Repo/assets/127345901/01cc07ee-548f-45e8-abb5-498bd321f535)

2. Run the docker cmd line below to deploy the APIdocker build -t gwisanidocker:v1 -f NS_Assignment/Dockerfile .
![image](https://github.com/Gwisani/Gwisani_Repo/assets/127345901/75d05bca-a643-41ce-976c-54274bf577b0)
![image](https://github.com/Gwisani/Gwisani_Repo/assets/127345901/68b90766-e00f-4abc-b8cf-51219748b715)

After this is done building, run the command below to start the api, and ensure the url is running before running the site. ![image](https://github.com/Gwisani/Gwisani_Repo/assets/127345901/2548bc9d-b762-4a25-8bf3-164002dc54a1)
![image](https://github.com/Gwisani/Gwisani_Repo/assets/127345901/81b62d8e-b7e6-4e0e-81f3-3840e4f13615)

This is how the api should look like when running through swagger
![image](https://github.com/Gwisani/Gwisani_Repo/assets/127345901/21d7b6de-3d1e-4537-988d-097481fcd115)
![image](https://github.com/Gwisani/Gwisani_Repo/assets/127345901/e00a226f-f7ae-4b20-a459-483650982e7f)

To run the website, select the NS_Assignemnt.Sites and press debug to run
![image](https://github.com/Gwisani/Gwisani_Repo/assets/127345901/e0aabbaf-3b52-4b71-8eca-4646cc469e3f)

if you changed the docker listening port, open the index.cshtml.cs code behind and enter the new one on the base url variable as shown below
![image](https://github.com/Gwisani/Gwisani_Repo/assets/127345901/1fe8ef98-6bca-4fdf-90f5-7723feac8bb9)

will open with this URL: https://localhost:7190/ and page will be like this

![image](https://github.com/Gwisani/Gwisani_Repo/assets/127345901/6015ddee-50a5-48b1-89a1-9fc28a259b84)


