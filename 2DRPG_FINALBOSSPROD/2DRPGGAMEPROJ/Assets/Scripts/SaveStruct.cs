using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters;
[Serializable()]
public class SaveStruct 
{
	[Serializable()]
	public class GameItems : ISerializable
	{
		public string ID;
		public string Name;
		public float posx;
		public float posy;
		public float posz;
		
		public GameItems()
		{
			ID = string.Empty;
			Name = string.Empty;
			posx = 0;
			posy = 0;
			posz = 0;
		}
		
		// Deserialization
		public GameItems(SerializationInfo info, StreamingContext ctxt)
		{
			ID = (String)info.GetValue("ID", typeof(string));
			Name = (String)info.GetValue("Name", typeof(string));
			posx = (float)info.GetValue("posx", typeof(float));
			posy = (float)info.GetValue("posy", typeof(float));
			posz = (float)info.GetValue("posz", typeof(float));
		}
		
		// Serialization
		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("ID", ID);
			info.AddValue("Name", Name);
			info.AddValue("posx", posx);
			info.AddValue("posy", posy);
			info.AddValue("posz", posz);
		}
	}
	

}