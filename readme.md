*DEV Comments*

To Run:
- Load project, build and press play.  A console application should be displayed showing the horses ordered by race, then 
  by price
- I have added Newtonsoft.Json package via Nuget, it may need to be downloaded before building

Other comments
- Both file types should be returning data correctly and also handle empty files
- Looking at the file examples, it looks like XML can contain multiple races so I have programmed it accordingly
- The main thing I would do differently if I had more time is to change the unit tests to use a mocking framework
  and mock out some of the returned data in the main service layer method.




# .NET Code Challenge

You've been provided with the shell of a .Net application in Visual Studio with some sample inputs 

Create an application which outputs the horse names in price ascending order. 

The code should be at a standard you'd feel comfortable with putting in production.

## Background

The source data reflects how BetEasy has different providers of data which feed our website.

The data files are used allows creation of different races:
* Caulfield_Race1.xml https://beteasy.com.au/racing-betting/horse-racing/caulfield/20171216/race-1-798068-25502504  
* Wolferhampton_Race1.json https://beteasy.com.au/racing-betting/horse-racing/wolverhampton/20171213/race-1-797507-25500650

## Guidelines

You can either complete the test prior to the interview or come in and do it as part of the technical interview. The application shell provided is a suggestion only, if C#/.Net isn't your preferred language/Framework please use what you're most comfortable with.

### At Home
* Please limit your time to 2 hours. If you don't complete it within this time just let us know what is outstanding.
* Commit your code at regular intervals so we can see how you reached your solution
* Once completed push to a public repo and share the link with us
* Please replace this ReadMe with any setup required

### At BetEasy
* The goal of this challenge is not to complete the exercise, but to give us an understanding on how you tackle problems. Please talk us through your thinking process & assumptions as you go.
* Feel free to use any resources you would normally use (Google, StackOverflow etc.)
* Please ask any questions you wish
* The coding exercise will be done on the developer test laptop (1141): Test // Wagering99