import vue from '@vitejs/plugin-vue'
import { defineConfig } from 'vite'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue()],
  build: {
    outDir: '../AllSpiceV2/wwwroot',
    sourcemap: false
  },
  server: {
    port: 8080
  }
})
