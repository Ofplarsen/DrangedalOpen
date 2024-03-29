import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// https://vitejs.dev/config/
export default defineConfig({
	resolve: { alias: { '@': '/src' } },
	plugins: [vue({
		// This is needed, or else Vite will try to find image paths (which it wont be able to find because this will be called on the web, not directly)
		// For example <img src="/images/logo.png"> will not work without the code below
		template: {
			transformAssetUrls: {
				includeAbsolute: false,
			},
		},
	}),],
	server: {
		host: true,
		port: 8080
	},
	build: {
		rollupOptions: {
			external: [
				/^node:.*/,
			]
		}
	}
})
