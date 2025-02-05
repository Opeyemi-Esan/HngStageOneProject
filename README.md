# Number Classification API  

## Table of Contents  

- [Overview](#overview)  
- [Features](#features)  
- [Technologies Used](#technologies-used)  
- [Getting Started](#getting-started)  
  - [Prerequisites](#prerequisites)  
  - [Installation](#installation)  
  - [Running the Application](#running-the-application)  
- [API Endpoints](#api-endpoints)  
  - [Classify Number](#classify-number)  
- [Error Handling](#error-handling)  
- [Future Improvements](#future-improvements)  
- [Contributing](#contributing)  
- [License](#license)  
- [Acknowledgments](#acknowledgments)  

## Overview  

Number Classification API is a RESTful web API built with .NET Core that classifies numbers based on mathematical properties and retrieves fun facts about those numbers. This project aims to provide an educational tool for exploring basic number theory in a fun and interactive way.  

## Features  

- **Number Classification**: Classifies numbers as Armstrong, Prime, Odd, or Perfect.  
- **Digit Summation**: Calculates the sum of digits of a given number.  
- **Fun Facts**: Fetches amusing facts about numbers from an external API.  
- **RESTful API**: Easily accessible and usable in various web and mobile applications.  

## Technologies Used  

- [.NET Core](https://dotnet.microsoft.com/download) (8.0 or later)  
- C#  
- ASP.NET Core MVC  
- Dependency Injection  
- HttpClient for API Calls  
- Newtonsoft.Json for JSON manipulation  

## Getting Started  

### Prerequisites  

Before you begin, ensure you have the following installed on your machine:  

- [.NET SDK](https://dotnet.microsoft.com/download) 8.0 or later  
- A code editor (e.g., Visual Studio, Visual Studio Code)  

### Installation  

1. Clone the repository:  
   ```bash  
   git clone https://github.com/Opeyemi-Esan/HngStageOneProject.git  
   cd HngStageOneProject

2. Restore the required packages
   ```bash
   dotnet restore


## Running the Application
  To run the application, use the following command:
  bash
  dotnet run
  
  The API will be available at https://localhost:7102


## API Endpoints
### Classify Number
- Endpoint: /api/number/classify-number

- Method: GET

- Query Parameter:
  number: The number to classify (must be a non-negative integer).
- Response: Returns a JSON object with classification results and a fun fact.

- Example Request:
  GET http://localhost:7102/api/number/classify-number?number=153


- Example Response:

      json
      {  
          "data": {  
              "number": 153,  
              "isPrime": false,  
              "isPerfect": false,  
              "properties": [  
                  "armstrong",  
                  "odd"  
              ],  
              "digitSum": 9,  
              "funFact": "153 is the sum of the cubes of its digits."  
          },  
          "message": "Number classified successfully.",  
          "statusCode": 200,  
          "success": true  
      }  
## Error Handling
  Invalid requests will return an appropriate HTTP status code along with a message detailing the error. For instance, a bad request will return:

    json
    {  
        "number": "abc",  
        "error": true,  
        "message": "Invalid number. Must be a non-negative integer."  
    }  
  
## Future Improvements
- Implement caching for fun facts to reduce the number of API calls.
- Add additional number classification properties.
- Improve error handling and input validation.
- Create unit and integration tests for critical features.

## Contributing
  Contributions are welcome! If you have suggestions for improvements or new features, please fork the repository and submit a pull request.

## License
  This project is licensed under the MIT License. See the LICENSE file for more details.

## Acknowledgments
- Thanks to the Numbers API for providing fun facts about numbers.
- Special thanks to all contributors and the open-source community.
