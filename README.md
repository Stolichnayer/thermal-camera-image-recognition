# Thermal Camera Image (or any image basically) Color recognition

A Desktop application for Windows made with C# for image pixels' or selected region's pixels RGB color and intensity recognition.

![](https://github.com/Stolichnayer/thermal-camera-image-recognition/blob/master/ThemalCameraImageRecognition/resources/application.gif)

Built with:
 * C# 7.3
 * .NET Framework 4.7.2
 * WinForms
 * Visual Studio 2019
 
 Functionalities:
  * Convert image to grayscale
  * Get cursor's location color and intensity of pixel
  * Draw a region with free-form selection and get average RGB color and intensity
  
  Video: <br>
   * https://www.youtube.com/watch?v=-wyiB_sq5wA <br> <br>
  [![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/-wyiB_sq5wA/0.jpg)](https://www.youtube.com/watch?v=-wyiB_sq5wA)
  
 NOTES:
  * C# Tasks are used in order to keep the UI responsive while calculating 
  * RGB Color average is currently just the mathimatical mean

TODO:
 * Find maybe a more accurate way of calculating the RGB average of the colors.
