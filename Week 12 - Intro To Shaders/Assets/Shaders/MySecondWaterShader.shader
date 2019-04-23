// call it anything you want.
Shader "Greg's Shaders Of Realness/Unlit Water Madness"
{
    // declare the main properties here...
    Properties
    {
        _MainTex ("Texture", 2D) = "white" 
        _WaveAmp ("Wave Amplitude", Float) = 0.5
        _ReflectionSpeed("Reflection Speed", Float) = .01
        _WaveFrequency("Wave Frequency", Float) = 0
        
    }

    // subshader is where the shader magic happens
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            // CGPROGRAM is where it all happens!  the 'Update' function of the shader.
            CGPROGRAM
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

            // these are declared automatically.   We will use them!
            sampler2D _MainTex;
            float4 _MainTex_ST;  // float4 is like a vector4 that uses floats.  for under-the-hood stuff, sometimes you need for vectors!

            float _WaveAmp;
            uniform float _WaveFrequency;
            float _ReflectionSpeed;

            // vertex part of the shader.  we're messing aroudn w verticies, to displace them!
            v2f vert (appdata v)
            {
                v2f o;

                // time to move some Vertices!!!  with _Time, which is like Time.Time
                v.vertex += float4 (
                    0,
                    sin((_Time.y + v.vertex.x + v.vertex.z) * _WaveFrequency) * _WaveAmp,
                    0,
                    0
                );               // surf on the sine waves with sin((_Time... etc))

                // then let the shader do the rest...
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            // fragment shader -- putting it all together.
            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv + float2(_Time.x, 1) * _ReflectionSpeed);  // offsetting the texture w time-based update calls   
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
