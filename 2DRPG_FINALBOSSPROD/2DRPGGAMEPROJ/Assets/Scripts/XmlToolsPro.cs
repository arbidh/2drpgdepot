using UnityEngine;
using System;
using System.Xml;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[ExecuteInEditMode]
[Serializable]

public static class XmlToolsPro  {






		public static XmlDocument inputXML(string filePath, string filename)
		{
				XmlDocument xmlDoc = new XmlDocument ();

				if (File.Exists (filePath + "/" + filename)) {

						TextReader m = File.OpenText (filePath + "/" + filename);
						//string _info = m.ReadToEnd ();
						XmlReader reader = XmlReader.Create (m);
						xmlDoc = new XmlDocument ();
				
			
						try {
								xmlDoc.Load (reader);
				
				
						} catch (Exception ex) {
								Debug.Log ("Error loading" + filename + ":\n" + ex);
				
						} finally {
				
								Debug.Log (filename + "loaded");
				
						}
			
						return xmlDoc;
				}
		return null;
			
		}
		
		public static void writeXML(string filePath, XmlDocument xmlDoc)
		{
			
			if (File.Exists (filePath)) {
				
				using (TextWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.UTF8)) {
					
					xmlDoc.Save (sw);
			
					
				}
				
				
				
			}
		}
		
		

}
