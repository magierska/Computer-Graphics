using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor
{
    public static class PaintingManager
    {
        static Vector3[,] BaseObject;
        static Vector3 LightColor;
        static Vector3[,] NormalVector;
        static Vector3[,] Disorder;
        static Vector3 LightVector;
        static bool constantLightVector;
        static Vector3 RedLantern, GreenLantern, BlueLantern, PictureBoxMiddle, VRedLantern, VGreenLantern, VBlueLantern;
        static bool RedLanternOn, GreenLanternOn, BlueLanternOn;

        public static void InitializeLanterns(Vector3 red, Vector3 green, Vector3 blue, Vector3 middle)
        {
            RedLantern = red;
            GreenLantern = green;
            BlueLantern = blue;
            PictureBoxMiddle = middle;

            VRedLantern = new Vector3(middle.X - red.X, middle.Y - red.Y, middle.Z - red.Z);
            double length = VRedLantern.Length();
            VRedLantern = new Vector3(VRedLantern.X / length, VRedLantern.Y / length, VRedLantern.Z / length);

            VGreenLantern = new Vector3(middle.X - green.X, middle.Y - green.Y, middle.Z - green.Z);
            length = VGreenLantern.Length();
            VRedLantern = new Vector3(VGreenLantern.X / length, VGreenLantern.Y / length, VGreenLantern.Z / length);

            VBlueLantern = new Vector3(middle.X - blue.X, middle.Y - blue.Y, middle.Z - blue.Z);
            length = VBlueLantern.Length();
            VBlueLantern = new Vector3(VBlueLantern.X / length, VBlueLantern.Y / length, VBlueLantern.Z / length);
        }
        public static void SetBaseObject(Color color)
        {
            BaseObject = new Vector3[1, 1] { { new Vector3((double)color.R / 255, (double)color.G/255, (double)color.B / 255) } };
        }
        public static void SetBaseObject(Bitmap bitmap)
        {
            BaseObject = new Vector3[bitmap.Width, bitmap.Height];
            for (int i = 0; i < bitmap.Width; i++)
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    BaseObject[i, j] = new Vector3((double)color.R / 255, (double)color.G / 255, (double)color.B / 255);
                }
        }
        public static void SetLightColor(Color color)
        {
            LightColor = new Vector3((double)color.R / 255, (double)color.G / 255, (double)color.B / 255);
        }
        public static void SetNormalVector(Vector3 vector)
        {
            NormalVector = new Vector3[1, 1] { { vector } };
        }
        public static void SetNormalVector(Bitmap bitmap)
        {
            NormalVector = new Vector3[bitmap.Width, bitmap.Height];
            int width = bitmap.Width, height = bitmap.Height;
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    NormalVector[i, j] = new Vector3((double)(color.R - 127) / 127, (double)(color.G - 127) / 127, (double)color.B / 255);
                    NormalVector[i, j].X = NormalVector[i, j].X / NormalVector[i, j].Z;
                    NormalVector[i, j].Y = NormalVector[i, j].Y / NormalVector[i,j].Z;
                    NormalVector[i, j].Z = 1;
                }
        }
        public static void SetDisorder(Vector3 vector)
        {
            Disorder = new Vector3[1, 1] { { vector } };
        }
        public static void SetDisorder(Bitmap bitmap, string fText)
        {
            double f = 0;
            double.TryParse(fText, out f);
            int width = bitmap.Width, height = bitmap.Height;
            Disorder = new Vector3[width, height];
            Vector3 T, B;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    Vector3 normalVector = NormalVector[i % NormalVector.GetLength(0), j % NormalVector.GetLength(1)];
                    T = new Vector3(1, 0, -normalVector.X);
                    B = new Vector3(0, 1, -normalVector.Y);
                    int dhx, dhy;
                    if (i + 1 >= width)
                        dhx = bitmap.GetPixel(0, j).R - color.R;
                    else
                        dhx = bitmap.GetPixel(i + 1, j).R - color.R;
                    if (j + 1 >= height)
                        dhy = bitmap.GetPixel(i, 0).R - color.R;
                    else
                        dhy = bitmap.GetPixel(i, j + 1).R - color.R;
                    Disorder[i, j] = new Vector3(
                        (T.X * dhx + B.X * dhy) * f,
                        (T.Y * dhx + B.Y * dhy) * f,
                        (T.Z * dhx + B.Z * dhy) * f);
                }
            }
        }
        public static void SetLightVector(Vector3 vector, bool constant)
        {
            LightVector = vector;
            constantLightVector = constant;
        }
        public static void SetLights(bool red, bool green, bool blue)
        {
            RedLanternOn = red;
            BlueLanternOn = blue;
            GreenLanternOn = green;
        }
        public static Vector3 GetRedLight(int x, int y)
        {
            if (!RedLanternOn)
                return new Vector3(0, 0, 0);
            Vector3 lightVector = new Vector3(x - RedLantern.X, y - RedLantern.Y, -RedLantern.Z);
            double length = lightVector.Length();
            lightVector.X /= length;
            lightVector.Y /= length;
            lightVector.Z /= length;
            double cos = VRedLantern.X * lightVector.X + VRedLantern.Y * lightVector.Y + VRedLantern.Z * lightVector.Z;
            Vector3 I = new Vector3(Math.Pow(cos, 1000), 0, 0);
            Vector3 normalWithDisorder = GetNormalVectorWithDisorder(x, y);
            double cos2 = normalWithDisorder.X * lightVector.X + normalWithDisorder.Y * lightVector.Y + normalWithDisorder.Z * lightVector.Z;
            Vector3 result = new Vector3(
                I.X * cos2,
                I.Y * cos2,
                I.Z * cos2);
            double length2 = result.Length();
            return new Vector3(
                result.X / length2,
                result.Y / length2,
                result.Z / length2
                );
        }
        public static Vector3 GetBlueLight(int x, int y)
        {
            if (!BlueLanternOn)
                return new Vector3(0, 0, 0);
            Vector3 lightVector = new Vector3(x - BlueLantern.X, y - BlueLantern.Y, -BlueLantern.Z);
            double length = lightVector.Length();
            lightVector.X /= length;
            lightVector.Y /= length;
            lightVector.Z /= length;
            double cos = VBlueLantern.X * lightVector.X + VBlueLantern.Y * lightVector.Y + VBlueLantern.Z * lightVector.Z;
            Vector3 I = new Vector3(0, 0, Math.Pow(cos, 1000));
            Vector3 normalWithDisorder = GetNormalVectorWithDisorder(x, y);
            double cos2 = normalWithDisorder.X * lightVector.X + normalWithDisorder.Y * lightVector.Y + normalWithDisorder.Z * lightVector.Z;
            Vector3 result = new Vector3(
                I.X * cos2,
                I.Y * cos2,
                I.Z * cos2);
            double length2 = result.Length();
            return new Vector3(
                result.X / length2,
                result.Y / length2,
                result.Z / length2
                );
        }
        public static Vector3 GetGreenLight(int x, int y)
        {
            if (!GreenLanternOn)
                return new Vector3(0, 0, 0);
            Vector3 lightVector = new Vector3(x - GreenLantern.X, y - GreenLantern.Y, -GreenLantern.Z);
            double length = lightVector.Length();
            lightVector.X /= length;
            lightVector.Y /= length;
            lightVector.Z /= length;
            double cos = VGreenLantern.X * lightVector.X + VGreenLantern.Y * lightVector.Y + VGreenLantern.Z * lightVector.Z;
            Vector3 I = new Vector3(0, Math.Pow(cos, 1000), 0);
            Vector3 normalWithDisorder = GetNormalVectorWithDisorder(x, y);
            double cos2 = normalWithDisorder.X * lightVector.X + normalWithDisorder.Y * lightVector.Y + normalWithDisorder.Z * lightVector.Z;
            Vector3 result = new Vector3(
            I.X * cos2,
            I.Y * cos2,
            I.Z * cos2);
            double length2 = result.Length();
            return new Vector3(
                result.X / length2,
                result.Y / length2,
                result.Z / length2
                );
        }
        static Vector3 GetNormalVectorWithDisorder(int x, int y)
        {
            Vector3 vector = new Vector3(
                NormalVector[x % NormalVector.GetLength(0),y % NormalVector.GetLength(1)].X + Disorder[x % Disorder.GetLength(0),y % Disorder.GetLength(1)].X,
                NormalVector[x % NormalVector.GetLength(0), y % NormalVector.GetLength(1)].Y + Disorder[x % Disorder.GetLength(0), y % Disorder.GetLength(1)].Y,
                NormalVector[x % NormalVector.GetLength(0), y % NormalVector.GetLength(1)].Z + Disorder[x % Disorder.GetLength(0), y % Disorder.GetLength(1)].Z
            );
            double length = vector.Length();
            vector.X /= length;
            vector.Y /= length;
            vector.Z /= length;
            return vector;
        }
        static Vector3 GetLightVector(int x, int y)
        {
            if (constantLightVector)
                return LightVector;
            Vector3 vector = new Vector3(Math.Abs(LightVector.X - x), Math.Abs(LightVector.Y - y), LightVector.Z);
            double length = vector.Length();
            vector.X /= length;
            vector.Y /= length;
            vector.Z /= length;
            return vector;
        }
        public static Color GetColor(int x, int y)
        {
            Vector3 baseObject = BaseObject[x % BaseObject.GetLength(0), y % BaseObject.GetLength(1)];
            Vector3 normalVector = GetNormalVectorWithDisorder(x, y);
            Vector3 lightVector = GetLightVector(x, y);
            double cos = (normalVector.X * lightVector.X + normalVector.Y * lightVector.Y + normalVector.Z * lightVector.Z);
            Vector3 redLantern = GetRedLight(x, y);
            Vector3 greenLantern = GetGreenLight(x, y);
            Vector3 blueLantern = GetBlueLight(x, y);
            int r = (int)(baseObject.X * LightColor.X * cos * 255 + baseObject.X * redLantern.X * 255 + baseObject.X * blueLantern.X * 255 + baseObject.X * greenLantern.X * 255);
            if (r < 0)
                r = 0;
            if (r > 255)
                r = 255;
            int g = (int)(baseObject.Y * LightColor.Y * cos * 255 + baseObject.Y * redLantern.Y * 255 + baseObject.Y * blueLantern.Y * 255 + baseObject.Y * greenLantern.Y * 255);
            if (g < 0)
                g = 0;
            if (g > 255)
                g = 255;
            int b = (int)(baseObject.Z * LightColor.Z * cos * 255 + baseObject.Z * redLantern.Z * 255 + baseObject.Z * blueLantern.Z * 255 + baseObject.Z * greenLantern.Z * 255);
            if (b < 0)
                b = 0;
            if (b > 255)
                b = 255;

            return Color.FromArgb(r, g, b);
        }
    }
}
