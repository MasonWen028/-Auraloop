import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import wasm from 'vite-plugin-wasm'
import path from 'path';
import Components from 'unplugin-vue-components/vite';
import { NaiveUiResolver } from 'unplugin-vue-components/resolvers';
import AutoImport from 'unplugin-auto-import/vite';

// https://vite.dev/config/
export default defineConfig({
  plugins: [
    vue(),    
    Components({
      resolvers: [NaiveUiResolver()]
    }),
    AutoImport({
      imports: [
        "vue",
        "vue-router",
        "@vueuse/core",
        {
          "naive-ui": ["useDialog", "useMessage", "useNotification", "useLoadingBar"],
        },
      ],
      eslintrc: {
        enabled: true,
        filepath: "./auto-eslint.mjs",
      },
    }),
    wasm()
  ],
  
    resolve: {
      alias: {
        '@': path.resolve(__dirname, './src')
      }
    }
})
