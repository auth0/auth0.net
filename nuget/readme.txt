PLEASE READ ME!!
----------------

Async method naming conventions:
-------------------------------

Version 2.x of the Auth0 .NET SDK has not followed the accepted naming convention for async methods by ending the method with an "Async" suffix. Many of the users reached out to us as this created confusion for them.

Starting with Version 3.x we are ensuring that all of our async methods end with the "Async" suffix to make it easier on you to recognize these and know to await them. 

The previous methods which do not conform to the naming convention are still there so your code does not break, but have been marked as Obsolete. We suggest that you update your code as soon as possible to make use of the correct xxxAsync methods.

Apologies for the confusion we caused many of you.