using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TetrahedronRotation;
public partial class BingSphereUC : UserControl
{
  public BingSphereUC()
  {
    InitializeComponent();
  }


  //  //You’re right.I apologize for the mistake. MeshGeometry3D is a sealed class and cannot be inherited.Here is an example of how you can create a custom method to generate a sphere mesh:
  //  public static MeshGeometry3D CreateSphereMesh(double radius, int slices, int stacks)
  //  {
  //    var mesh = new MeshGeometry3D();
  //    var positions = new Point3DCollection();
  //    var indices = new Int32Collection();
  //    var normals = new Vector3DCollection();
  //    var textureCoords = new PointCollection();

  //    for (int stack = 0; stack <= stacks; stack++)
  //    {
  //      double phi = Math.PI / 2 - stack * Math.PI / stacks;
  //      double y = radius * Math.Sin(phi);
  //      double scale = -radius * Math.Cos(phi);

  //      for (int slice = 0; slice <= slices; slice++)
  //      {
  //        double theta = slice * 2 * Math.PI / slices;
  //        double x = scale * Math.Sin(theta);
  //        double z = scale * Math.Cos(theta);

  //        Vector3D normal = new Vector3D(x, y, z);
  //        normals.Add(normal);
  //        positions.Add(normal);
  //        textureCoords.Add(new Point((double)slice / slices, (double)stack / stacks));
  //      }
  //    }

  //    for (int stack = 0; stack <= stacks; stack++)
  //    {
  //      int top = (stack + 0) * (slices + 1);
  //      int bot = (stack + 1) * (slices + 1);

  //      for (int slice = 0; slice < slices; slice++)
  //      {
  //        if (stack != 0)
  //        {
  //          indices.Add(top + slice);
  //          indices.Add(bot + slice);
  //          indices.Add(top + slice + 1);
  //        }

  //        if (stack != stacks - 1)
  //        {
  //          indices.Add(top + slice + 1);
  //          indices.Add(bot + slice);
  //          indices.Add(bot + slice + 1);
  //        }
  //      }
  //    }

  //    mesh.Positions = positions;
  //    mesh.TriangleIndices = indices;
  //    mesh.Normals = normals;
  //    mesh.TextureCoordinates = textureCoords;

  //    return mesh;
  //  }
  //  //
  //  //You can then use this custom method in your code to generate a sphere mesh and assign it to the Geometry property of a GeometryModel3D object in your XAML code.
}

//// You’re right.I apologize for the mistake. SphereMesh is not a built-in class in .NET.You can use a third-party library or create your own custom class to generate a sphere mesh.Here is an example of how you can create a custom SphereMesh class:

//public class SphereMesh : MeshGeometry3D
//{
//  public double Radius { get; set; }
//  public int Slices { get; set; }
//  public int Stacks { get; set; }
//  public SphereMesh()
//  {
//    Radius = 1;
//    Slices = 32;
//    Stacks = 32;
//  }

//  protected override void OnChanged()
//  {
//    var positions = new Point3DCollection();
//    var indices = new Int32Collection();
//    var normals = new Vector3DCollection();
//    var textureCoords = new PointCollection();

//    for (int stack = 0; stack <= Stacks; stack++)
//    {
//      double phi = Math.PI / 2 - stack * Math.PI / Stacks;
//      double y = Radius * Math.Sin(phi);
//      double scale = -Radius * Math.Cos(phi);

//      for (int slice = 0; slice <= Slices; slice++)
//      {
//        double theta = slice * 2 * Math.PI / Slices;
//        double x = scale * Math.Sin(theta);
//        double z = scale * Math.Cos(theta);

//        Vector3D normal = new Vector3D(x, y, z);
//        normals.Add(normal);
//        positions.Add(normal + Center);
//        textureCoords.Add(new Point((double)slice / Slices, (double)stack / Stacks));
//      }
//    }

//    for (int stack = 0; stack <= Stacks; stack++)
//    {
//      int top = (stack + 0) * (Slices + 1);
//      int bot = (stack + 1) * (Slices + 1);

//      for (int slice = 0; slice < Slices; slice++)
//      {
//        if (stack != 0)
//        {
//          indices.Add(top + slice);
//          indices.Add(bot + slice);
//          indices.Add(top + slice + 1);
//        }

//        if (stack != Stacks - 1)
//        {
//          indices.Add(top + slice + 1);
//          indices.Add(bot + slice);
//          indices.Add(bot + slice + 1);
//        }
//      }
//    }

//    Positions = positions;
//    TriangleIndices = indices;
//    Normals = normals;
//    TextureCoordinates = textureCoords;

//    base.OnChanged();
//  }
//}


