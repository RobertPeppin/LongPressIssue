# LongPressIssue
Example XF App showing possible issue with LongPress detection

When a press begins, the ripple effect starts it's animation. Once the required time has passed, the command is called for a long press.

The issue occurs when during the ripple animation but before the long press event has fired, if the finger/mouse moves the animation never clears and the command is not called. My assumption is that this long press has become a drag at this point.


