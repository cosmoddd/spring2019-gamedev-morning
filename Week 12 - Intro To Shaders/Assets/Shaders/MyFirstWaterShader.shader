// defines the name for Unity Editor to use
Shader "Robert's Custom Shaders/MyFirstWaterShader"
{
    // Properties are like the "public variables" of a shader
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		
		_WaveAmp ("Wave Amplitude", Float) = 0.5
		_WaveFreq ("Wave Frequency", Float) = 1.1
	}
	// SubShader is where you actually start writing shader stuff?
	SubShader
	{   // Render Tags toggle different behavior inside Unity (e.g. transparency)
		Tags { "RenderType"="Opaque" }
		// "level of detail" = distance-based optimization
		LOD 100

        // "Pass" is like an Update loop
		Pass
		{
		    // CGPROGRAM marks the start of CG code (HLSL)
			CGPROGRAM
			// "pragma" = compiler directive... here, we're defining variables / binding stuff
			#pragma vertex vert 
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			
            // declaring some variables to use
			sampler2D _MainTex;
			float4 _MainTex_ST; // float4 is like a Vector4 that uses floats
			
			// we always must declare a "twin" Property var, in order to use it
			float _WaveAmp;
			float _WaveFreq;
			
			// VERTEX SHADER!!!!
			v2f vert (appdata v)
			{
				v2f o;
				// _Time is like Time.time
				v.vertex += float4(
				    0, 
				    sin( (_Time.y + v.vertex.x + v.vertex.z) * _WaveFreq ) * _WaveAmp, 
				    0, 
				    0
				);
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			// FRAGMENT SHADER = rasterize, color, fill-in, texture, etc.
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				// fixed4 is like a float4 / Vector4, but with fixed precision
				fixed4 col = tex2D(_MainTex, i.uv + float2(_Time.y, _Time.y) );
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
			// ENDCG = the end of CG / HLSL code
		}
	}
}
