# 7Belo Candy - Unity 6 Asset

## Contents
- `7Belo_Candy.fbx` — low-poly FBX mesh with separate body, logo panel and two wrapper tails.
- `textures/7belo_main_label.png` — blue front label artwork.
- `textures/red_diamond_cellophane.png` — red diamond-check cellophane pattern.
- `7Belo_Candy.obj` / `.mtl` — optional fallback interchange files.

## Model notes
- Long axis: X; up axis: Y. Pivot at the center of the candy.
- Approximate overall size: 0.09 m long, 0.022 m wide, 0.008 m thick (the wrapper tails are deliberately crinkled and slightly wider).
- Low-poly topology with separate meshes/material assignments and UV coordinates.
- The body, front logo panel and each cellophane tail are separate objects in the FBX hierarchy.

## Unity import
1. Extract the ZIP or copy the entire `7Belo_Unity_Asset` folder into `Assets/`. Keep the `textures` folder beside the FBX.
2. Select `7Belo_Candy.fbx` and use Scale Factor `1`.
3. For the two texture files, set Texture Type to `Default`, sRGB (Color Texture) on, and Max Size 2048.
4. If Unity does not auto-connect the image files on import, create two URP/Lit materials: assign `7belo_main_label.png` to the label material Base Map and `red_diamond_cellophane.png` to the red tail material Base Map. Use the blue polymer material for the main body.
5. Optional: enable GPU instancing if you place many candy pickups in a scene.

## Notes
This is a stylized low-poly recreation based on the provided reference, not an exact scan of the original package. The lettering and decorative print are part of the label texture; the mesh remains intentionally lightweight.
