// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Hazy Way"
{
	Properties
	{
		_DeepHaze("Deep Haze", 2D) = "white" {}
		_HazeColor("Haze Color", Color) = (0,0,0,0)
		_VertexOffset("Vertex Offset", Range( 0 , 1)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows vertex:vertexDataFunc 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform float _VertexOffset;
		uniform sampler2D _DeepHaze;
		uniform float4 _DeepHaze_ST;
		uniform float4 _HazeColor;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float3 _Vector0 = float3(0,0,0);
			float4 appendResult13 = (float4(_Vector0.x , _VertexOffset , _Vector0.z , 0.0));
			v.vertex.xyz += appendResult13.xyz;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_DeepHaze = i.uv_texcoord * _DeepHaze_ST.xy + _DeepHaze_ST.zw;
			o.Albedo = ( tex2D( _DeepHaze, uv_DeepHaze ) * _HazeColor ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=16500
142.8;456;1052;651;994.364;6.298923;1.406989;True;False
Node;AmplifyShaderEditor.Vector3Node;12;-403.4289,289.1686;Float;False;Constant;_Vector0;Vector 0;3;0;Create;True;0;0;False;0;0,0,0;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;11;-497.1098,191.6934;Float;False;Property;_VertexOffset;Vertex Offset;2;0;Create;True;0;0;False;0;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;3;-501.3769,-38.03332;Float;False;Property;_HazeColor;Haze Color;1;0;Create;True;0;0;False;0;0,0,0,0;0.04060721,1,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;1;-402.0528,-396.6915;Float;True;Property;_DeepHaze;Deep Haze;0;0;Create;True;0;0;False;0;None;1310c389b00742944a196851ef347845;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;13;-116.4031,134.3999;Float;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;2;-99.82703,-157.9962;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;115,-132.9;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;Hazy Way;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;13;0;12;1
WireConnection;13;1;11;0
WireConnection;13;2;12;3
WireConnection;2;0;1;0
WireConnection;2;1;3;0
WireConnection;0;0;2;0
WireConnection;0;11;13;0
ASEEND*/
//CHKSM=527F70568D50B8413A15608CA2B62878717ECC0E