CoffeeMaker Application

Windows Forms Project by: Tamara Deleva, Aleksandar Partaloski and Marija Klisarovska

---

Descritpion of the application

The application represents a simple and easily usable coffee shop application with a simple design that let's a certain user order a coffee of his liking, and after that, the player recieves the bill and a simple design shows the user the progress of his coffee being made.

---

How the game is played

The player chooses a coffee and is able to add sugar to the coffee if he wants to. After that, the player is shown the form in which he chooses the amount of money he wishes to pay with or he can back out and change the coffee and the amount of sugar he likes. If the player chooses the option to continue, he will be shown a form in which the proccess of making the coffee is visualised. After the proccess is done, the player will be met with the message "Thank you for ordering", indicating that the proccess is done, and if he wants to keep ordering another coffee he will have a button at the bottom that goes back to the initial form where he can repeat the proccess of ordering another coffee.

---

Screenshots of the game

On the following screenshot is a picture of the first form which you see when starting the application, which shows the coffees available, their prices and the amount of sugar that can be added to the coffee.

1.
![coffee1form](https://github.com/user-attachments/assets/f45b4e4b-8447-4bba-b8b1-3ae6bf6b59cd)

On the second screenshot is a picture which let's you add a certain amount of money you wish to pay for the coffee with. If you don't wish to continue with the payment, you may click the button "Back to Selection" which puts you on the first form where you can change your coffee option.

2.
![coffe2form](https://github.com/user-attachments/assets/0602d83a-b7f6-4b7a-8eeb-401abe972ac1)

On the third and last picture, you are shown the progress of the coffee being poured in a cup with the amount of milk used, and the amount of sugar. After the process is done you may stop the application, or you can go back to ordering another coffee and repeat the same process yet again.

3.
![coffee3form](https://github.com/user-attachments/assets/5f654da4-332e-48bf-a711-2533288732c9)

---

Explanation of some of the classes and CoffeeOrder.cs and Animation.cs

In the CoffeeOrder.cs class is the making of the final order by the customer, with the coffee selection and the amount of sugar, if it is added, regulated with the values of selectedCoffee of CoffeeOption type(which is the basic function for the name and price of a coffee item), bool type of added sugar and integer type of amount of sugar teaspoons if added. An object of this class is called in the progress form.

The Animation.cs class is a class for the filling of the cup based on the order, and each order (type of coffee) add different ingredients in the cup based on the recipe of the coffee. The recipes and the colors of each ingredient are kept in 2 different dictionaries in the progress form. In this class, the fillSegment method is called for each ingredient of a coffee order. In that method, the filling is done with drawing an ellipse in the form of the empty cup image, customised with it's size and the form dimensions. Before drawing and filling the ellipse, a Snip of a Rectangle with the right dimensions and needed amount of the ingredient is made, so when the ellipse is drawn and filled, only the snipped part is shown on the form. The last segment on top that doesn't have a label is showing the added sugar, which is thicker with every teaspoon plus.

CoffeeOrder.cs:
![image](https://github.com/user-attachments/assets/fa42aaa2-d0e1-407b-96fb-3d538411673b)

Animation.cs:
![image](https://github.com/user-attachments/assets/2c8dae2c-5679-485c-80ab-3e0a0cef8262)

