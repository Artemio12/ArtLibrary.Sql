using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ArtLibrary.Sql
{
    public class AdderSqlImageParams
    {
        public void Add(SqlCommand cmd, List<string> pictureColumnNames, List<Image> images, ImageFormat imageFormat)
        {
            foreach (var element in pictureColumnNames.Zip(images,Tuple.Create))
            {
                Add(cmd, element.Item1, element.Item2, imageFormat);
            }
        }

        public void Add(SqlCommand cmd, string pictureColumnName, Image image, ImageFormat imageFormat)
        {
            var uploadedImage = new Bitmap(image);
            using (var stream = new MemoryStream())
            {
                uploadedImage.Save(stream, imageFormat);
                stream.Position = 0;
                var sqlParameter = new SqlParameter(pictureColumnName, SqlDbType.VarBinary, (int)stream.Length)
                { Value = stream.ToArray() };

                cmd.Parameters.Add(sqlParameter);
            }
        }
    }
}
