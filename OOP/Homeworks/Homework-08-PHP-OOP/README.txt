I had to put all files in the same directory in order to use auto-loading.
Couldn't figure out how to do it in another way as I couldn't make spl_autoload work.

I followed the encapsulation rules we're used to, using type hinting and type validation on most fields.

I wanted to make sure the guest's id was an integer, but it kept throwing errors regardless of the function I tried (is_int, is_long, etc.),
so I used is_numeric, which will return true for a floating-point value as well.