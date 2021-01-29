Shader "Custom/TerrainHighlight"{
    Properties{
        _MainTex("Texture", 2D) = "white" {}
        _MainColor("Main Color", Color) = (0,1,0)
        _SquareColor("SquareColor", Color) = (1,0,0)
        _Center("Center", Vector) = (0,0,0,0)
        _HalfSide("HalfSide", Range(0,100)) = 10
    }
        SubShader{
            CGPROGRAM
            #pragma surface surfaceFunc Lambert

            sampler2D _MainTex;
            fixed3 _MainColor;
            fixed3 _SquareColor;
            float3 _Center;
            float _HalfSide;

            struct Input{
                float2 uv_MainTex;
                float3 worldPos;
            };

            void surfaceFunc(Input In, inout SurfaceOutput o){
                half4 c = tex2D(_MainTex, In.uv_MainTex);
                float d = distance(float2(_Center.x,_Center.z), float2(In.worldPos.x,In.worldPos.z));

                float dx = abs(_Center.x - In.worldPos.x);
                float dz = abs(_Center.z - In.worldPos.z);

                if(dx < _HalfSide && dz < _HalfSide){
                    o.Albedo = _SquareColor;
                }
                else{
                    o.Albedo = c.rgb;
                }
                o.Alpha = c.a;
            }
            ENDCG
        }
}