# BankAccounts

**Task 1**

Bank "A" needs to develop a consultant program to view customer data. The consultant does not have rights to change or
view some of the data. Create a class that will contain the following fields:

Surname Name middle name Phone number Series, passport number Implement accessor methods for the following situations:

The consultant does not have access to view information. Instead of a series and a passport number, he sees the
characters: "******************" - if the field is not empty. The consultant cannot change the fields "Last Name", "
First Name", "Patronymic", but can view them. The consultant can change the "Phone number", but the field must always be
filled.

**Task 2**

We expand the program from task 1. We have a class for a consultant with its own methods and fields. Add a new class to
the program for the new user, manager.

The manager inherits the consultant's functionality in addition to his own. In this case, the manager can only add "Last
Name", "First Name", "Patronymic", "Phone", "Series, Passport Number".

**Task 3**

We expand and change the program from tasks 1 and 2. We have two classes for a consultant and a manager. Classes have a
method for changing data. Based on this, add additional fields to the data from task 1:

date and time the entry was modified; what data has been changed; type of change; who changed the data (consultant or
manager). And also create interfaces and implement in them methods for changing an existing record for a consultant and
manager. For the manager, allow adding a new entry. The new fields need to be filled in as soon as customer records have
been changed. Now the consultant can change only the client's phone number, and the manager can change all the data.
