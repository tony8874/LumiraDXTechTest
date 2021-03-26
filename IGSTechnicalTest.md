# IGS TechnicalTest

## Prerequisites:

1. Install MS Visual Studio Community 2019 edition.
2. From MS Visual Studio, select MS Project 'LumiraDXTech.sln' downloaded in step 3.
3. From MS Visual Studio, select 'Test Explorer' from the 'Test' drop down menu
4. From the 'Test Explorer' window, select Run all tests.

## Defect Report:

Defect report(.xlsx file) embedded in the VS project.


## Observations:

1. The POST API call permits duplicate categories to be added.


## Test Breakdown:
```
Test Name - AddProductRequest (POST http://localhost:5000/api/product)
  Tests(2):
        1. Verify status code response to valid request.
        2. Verify new category added with valid request.
        
Test Name - SingleProductRequest (GET http://localhost:5000/api/product/{id})
  Tests(5):
        1. Verify status code response with valid request.
        2. Verify content-type Header response with valid request.
        3. Verify Response Body with valid request.
        4. Verify JSON Schema with valid request.
        5. Verify status code response with invalid request.
        
 Test Name - ProductListRequest (GET http://localhost:5000/api/products)
   Tests(3):
        1. Verify status code response with valid request.
        2. Verify content-type Header response with valid request.
        3. Verify JSON Schema with valid request.
        
 Test Name - DeleteProductRequest (DELETE http://localhost:5000/api/product/{id})
   Tests(6):
        1. Verify status code response with valid request.
        2. Verify category deleted successfully with valid request.
        3. Verify status code response with invalid request.
        
 Test Name - UpdateCategoryRequest (PUT http://localhost:5000/api/product/{id})
   Tests(7):
        1. Verify status code response with valid request.
        2. Verify content-type Header response with valid request.
        4. Verify Category updated successfully.
        5. Verify status code response with invalid request.
        6. Verify content-type Header response with invalid request.

```
