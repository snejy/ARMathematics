Shader "Outlined/Outline with transperancy" {
	Properties {
		_LineColor("Line Color", Color) = (1,1,1,1)
		_GridColor("Grid Color", Color) = (0,0,0,0)
		_LineWidth("Line Width", float) = 0.1
		_MainTex ("Maintexture", 2D) = "white" {}
		_Color("Main Color",Color) = (0,0,0,0)
	}
  
	SubShader {
	Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
	
	//Pass{
	//		ZWrite On
	//	
	//		//Blend SrcAlpha OneMinusSrcAlpha
	//	 
	//		//ColorMask RGB
	//		Material
	//	{
	//		Diffuse[_Color]
	//		Ambient[_Color]
	//	}
	//		Lighting On
	//		SetTexture[_MainTex]
	//	{
	//		Combine texture * primary DOUBLE, texture * primary
	//	}
	//	}
		Pass {
			Name "OUTLINE"
			LOD 200
			Cull Off
			ZWrite Off
			//Blend Zero One
			// you can choose what kind of blending mode you want for the outline
			Blend SrcAlpha OneMinusSrcAlpha // Normal
			//Blend One One // Additive
			//Blend One OneMinusDstColor // Soft Additive
			//Blend DstColor Zero // Multiplicative
			//Blend DstColor SrcColor // 2x Multiplicative
 
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

uniform float4 _LineColor;
		uniform float4 _GridColor;
		uniform float _LineWidth;

		// vertex input: position, uv1, uv2
		struct appdata {
			float4 vertex : POSITION;
			float4 texcoord1 : TEXCOORD0;
			float4 color : COLOR;
		};

		struct v2f {
			float4 pos : POSITION;
			float4 texcoord1 : TEXCOORD0;
			float4 color : COLOR;
		};

		v2f vert(appdata v) {
			v2f o;
			o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
			o.texcoord1 = v.texcoord1;
			o.color = v.color;
			return o;
		}

		float4 frag(v2f i) : COLOR
		{
			float2 uv = i.texcoord1;
			float d = uv.x - uv.y;
			if (uv.x < _LineWidth)                     // 0,0 to 1,0
				return _LineColor;
			else if (uv.x > 1 - _LineWidth)             // 1,0 to 1,1
				return _LineColor;
			else if (uv.y < _LineWidth)                 // 0,0 to 0,1
				return _LineColor;
			else if (uv.y > 1 - _LineWidth)             // 0,1 to 1,1
				return _LineColor;
			//else if(d < _LineWidth && d > -_LineWidth) // 0,0 to 1,1
			//    return _LineColor;
			else
				return _GridColor;
		}
ENDCG
		}
		
	}
	Fallback "Diffuse"
}