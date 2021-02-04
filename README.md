# LumiraDXTechTest

## Prerequisites:

1. Fresh install of 'rest_api_demo' https://github.com/amaccormack-lumira/rest_api_demo/archive/techtest1.1.zip.
2. Follow Install instructions https://github.com/amaccormack-lumira/rest_api_demo/blob/master/README.md
4. Download API Automation test suite from link https://github.com/tony8874/LumiraDXTechTest.git
5. Install MS Visual Studio Community 2019 edition.
6. From MS Visual Studio, select MS Project 'LumiraDXTech.sln'.
7. From MS Visual Studio, select 'Test Explorer' from the 'Test' drop down menu
8. From the 'Test Explorer' window, select Run all tests.

## Defect Report:

Defect report(.xlsx file) embedded in the VS project.


## Observations:

1. The POST API call permits duplicate categories to be added.

```
Test Breakdown:

### Test Name - AddCategoryRequest
  Test:
        1. Check valid status code response.
        2. Check valid content-type Header response.
        3. Check new category added.
### Test Name - CategoryBlogRequest
  Test:
        1. Check valid status sode response.
        2. Check valid content-type Header response.
        3. Check Response Body
        4. Check JSON Schema
        5. 
```
