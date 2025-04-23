using System;


namespace SmartPillMauiApp.Helpers
{
    public class FileHelper
    {

        public static string GetFileNameWithExtension(string imagePath)
        {
            // تحقق إذا كان المسار يحتوي على شرطة مائلة
            int lastBackslashIndex = imagePath.LastIndexOf('\\');

            // إذا كانت هناك شرطة مائلة في المسار، قم بقطع المسار إلى اسم الملف فقط
            if (lastBackslashIndex != -1)
            {
                return imagePath.Substring(lastBackslashIndex + 1);
            }

            // إذا لم تكن هناك شرطة مائلة، فهذا يعني أن المسار هو اسم الملف فقط
            return imagePath;
        }

    }
}
