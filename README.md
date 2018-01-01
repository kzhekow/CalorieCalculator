# Calorie Calculator

## Project – Calorie Counter

## Short Description:
The calorie counter application that helps you track your personal daily nutrition goals.
## Team Members

-Alek Hristov
-Kristiyan Zhekov
-Nikolay Nikolov

## App Description

### The calorie counter is an application has the following functionalities:

#### Create Product

Creates a food product/drink with nutrient info:
Calories per 100 grams
Proteins per 100 grams
Carbs per 100 grams
Fat per 100 grams
Sugar per 100 grams
Fiber per 100 grams

Which is then stored locally using JSON serilization and can be later reused.

#### Create Meal

Creates a meal that can be reused in the future, it consists of a few products.
It contains the following info:
Total calories
Total proteins
Total carbs
Total fat
Total sugar
Total fiber

Which is then stored locally using JSON and can be reused in the future

#### Create Goal

Creates a goal once, and it contains the following:
Initial weight
Goal weight
Goal type: lose weight, maintain weight, gain weight
Calculates resting energy
Calculates daily calorie intake
Calculates suggested macros ratio
Calculates suggest daily water intake

#### Add Consumed Products

Adds a product to the current day
Calculates current daily calorie intake
Calculates macros ratio

#### Add Water  
Adds water in milliliters to the current day
Calculates current daily water intake

#### Add Activity
Adds an activity to the current day
Activity can be 2 types: Cardio and Strength training
It calculates burned calories depending on type of activity and duration
Recalculates the daily calorie intake, taking in mind burned calories during performing the activity

#### Show remaning nutrients 

Shows remaining nutrients for the current day
Calculates current and remaining daily calorie intake, considering activity performing
Calculates macros ratio
Calculates current daily water intake

## Link
https://github.com/kzhekow/CalorieCalculator
