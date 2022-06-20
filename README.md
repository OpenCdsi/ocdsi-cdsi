# cdsi
Clinical decision support for immunizations.

This is the nth iteration of this project. Maybe this time!

## Thoughts On Architecture

Being that .NET is an object-oriented framework one would think that OOP
would be the way to go; I however, balked at the shear number of entities
in the neighborhood diagrams of the Logic Spec and decided to pull an idea
from functional programming - data is transformed as it passes through different
functions.

### Data

Classes are simple property bags. Unlike actual functional programming, data
is mutable.

#### Supporting Data

The supporting data and testcases provided by the CDC are in the form of Excel 
spreadsheets. In the case of the supporting data, classes were pulled from the 
XML schema file and for the testcase spreadsheet, classes were created from the
column names and datatypes.

Generic methods are provided to convert these OOP objects into our data
objects. For example, there is a method to transform a testcase into a 
SimpleEhr.Patient object.

### Functions

The transformation functions are generic methods on the different data classes.
