Shader "TDA/DepthMask"
{
	Properties
	{
		[IntRange] _StencilID("Stencil ID", Range(0,255))=0
		[Range] _DissolveAmount("Dissolve Amount", Range(0, 1)) = 0.0
	}

	SubShader{

		Tags {
			"RenderType" = "Opaque" "Queue"="Geometry-1" "RenderPipeline"="UniversalPipeline"
		}

		Pass {
			Blend Zero One			
			ZWrite Off

			Stencil
			{
				Ref [_StencilID]
				Comp Always
				Pass Replace
			}
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata_t
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _DissolveAmount = 0.5;

			v2f vert(appdata_t v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			half4 frag(v2f i) : SV_Target
			{
				// Dissolve efekti uygulamak i�in _DissolveAmount kullan�n
				half4 texColor = tex2D(_MainTex, i.uv);
				texColor.a *= 1.0 - _DissolveAmount; // Dissolve Amount'a ba�l� olarak �effafl�k ekleyin
				return texColor;
			}
			ENDCG
		}
	}
}