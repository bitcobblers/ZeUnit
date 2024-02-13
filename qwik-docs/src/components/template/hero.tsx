import { component$ } from "@builder.io/qwik"
import blurCyanImage from '../../../public/images/blur-cyan.png' 
import blurIndigoImage from '../../../public/images/blur-indigo.png'
import { Link } from "@builder.io/qwik-city"
import HeroBackground from "./hero-background"
import Highlight from "./highlight"
 
const codeLanguage = 'csharp'
 const code = `<span class="token keyword">public</span> <span class="token keyword">class</span> <span class="token class-name">BarebondesSuite</span>
 <span class="token punctuation">{</span>
     <span class="token keyword">public</span> <span class="token return-type class-name">Fact</span> <span class="token function">GetExpectedValue</span><span class="token punctuation">(</span><span class="token punctuation">)</span>
     <span class="token punctuation">{</span>   
         <span class="token class-name"><span class="token keyword">var</span></span> actual <span class="token operator">=</span> <span class="token function">GetSomeString</span><span class="token punctuation">(</span><span class="token punctuation">)</span><span class="token punctuation">;</span>    
         <span class="token keyword">return</span> actual <span class="token operator">==</span> <span class="token string">"expected"</span><span class="token punctuation">;</span>
     <span class="token punctuation">}</span>
 <span class="token punctuation">}</span>
 `

const tabs = [
   { name: 'ZeUnitTest.cs', isActive: true }   
]

const TrafficLightsIcon = component$((props: any) => {
  return (
    <svg aria-hidden="true" viewBox="0 0 42 10" fill="none" {...props}>
      <circle cx="5" cy="5" r="4.5" />
      <circle cx="21" cy="5" r="4.5" />
      <circle cx="37" cy="5" r="4.5" />
    </svg>
  )
});

export function Hero() {
 
    return (
    <div class="overflow-hidden bg-slate-900 dark:-mb-32 dark:mt-[-4.75rem] dark:pb-32 dark:pt-[4.75rem]">
      <div class="py-16 sm:px-2 lg:relative lg:px-0 lg:py-20">
        <div class="mx-auto grid max-w-2xl grid-cols-1 items-center gap-x-8 gap-y-16 px-4 lg:max-w-8xl lg:grid-cols-2 lg:px-8 xl:gap-x-16 xl:px-12">
          <div class="relative z-10 md:text-center lg:text-left">
            <img
              class="absolute bottom-full right-full -mb-56 -mr-72 opacity-50"
              src={blurCyanImage}
              alt=""
              width={530}
              height={530}                          
            />
            <div class="relative">
              <p class="inline bg-gradient-to-r from-indigo-200 via-sky-400 to-indigo-200 bg-clip-text font-display text-5xl tracking-tight text-transparent">
                ZeUnit Testing Framework
              </p>
              <p class="mt-3 text-2xl tracking-tight text-slate-400">
                    From <span class="text-sky-400 ">barebones</span> to the full <span class="text-sky-400">kitchen sink</span> and everything in between. <span class="text-sky-400 ">ZeUnit</span> garantees writing tests isn't a bottleneck.
              </p>
              <div class="mt-8 flex gap-4 md:justify-center lg:justify-start">
                <Link type="button" href="/docs/getting-started" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 dark:bg-blue-600 dark:hover:bg-blue-700 focus:outline-none dark:focus:ring-blue-800">Get started</Link>
                <Link type="button" href="https://github.com/bitcobblers/ZeUnit" target="_blank" class="text-white bg-[#24292F] hover:bg-[#24292F]/90 focus:ring-4 focus:outline-none focus:ring-[#24292F]/50 font-medium rounded-lg text-sm px-5 py-2.5 text-center inline-flex items-center dark:focus:ring-gray-500 dark:hover:bg-[#050708]/30 me-2 mb-2">
                    <svg class="w-4 h-4 me-2" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 20">
                    <path fill-rule="evenodd" d="M10 .333A9.911 9.911 0 0 0 6.866 19.65c.5.092.678-.215.678-.477 0-.237-.01-1.017-.014-1.845-2.757.6-3.338-1.169-3.338-1.169a2.627 2.627 0 0 0-1.1-1.451c-.9-.615.07-.6.07-.6a2.084 2.084 0 0 1 1.518 1.021 2.11 2.11 0 0 0 2.884.823c.044-.503.268-.973.63-1.325-2.2-.25-4.516-1.1-4.516-4.9A3.832 3.832 0 0 1 4.7 7.068a3.56 3.56 0 0 1 .095-2.623s.832-.266 2.726 1.016a9.409 9.409 0 0 1 4.962 0c1.89-1.282 2.717-1.016 2.717-1.016.366.83.402 1.768.1 2.623a3.827 3.827 0 0 1 1.02 2.659c0 3.807-2.319 4.644-4.525 4.889a2.366 2.366 0 0 1 .673 1.834c0 1.326-.012 2.394-.012 2.72 0 .263.18.572.681.475A9.911 9.911 0 0 0 10 .333Z" clip-rule="evenodd"/>
                    </svg>
                    View on GitHub
                </Link>
              </div>
            </div>
          </div>
          <div class="relative lg:static xl:pl-10">
            <div class="absolute inset-x-[-50vw] -bottom-48 -top-32 [mask-image:linear-gradient(transparent,white,white)] lg:-bottom-32 lg:-top-32 lg:left-[calc(50%+14rem)] lg:right-0 lg:[mask-image:none] dark:[mask-image:linear-gradient(transparent,white,transparent)] lg:dark:[mask-image:linear-gradient(white,white,transparent)]">
              <HeroBackground class="absolute left-1/2 top-1/2 -translate-x-1/2 -translate-y-1/2 lg:left-0 lg:translate-x-0 lg:translate-y-[-60%]" />
            </div>
            <div class="relative">
              <img
                class="absolute -right-64 -top-64"
                src={blurCyanImage}
                alt=""
                width={530}
                height={530}                
              />
              <img
                class="absolute -bottom-40 -right-44"
                src={blurIndigoImage}
                alt=""
                width={567}
                height={567}                
              />
              <div class="absolute inset-0 rounded-2xl bg-gradient-to-tr from-sky-300 via-sky-300/70 to-blue-300 opacity-10 blur-lg" />
              <div class="absolute inset-0 rounded-2xl bg-gradient-to-tr from-sky-300 via-sky-300/70 to-blue-300 opacity-10" />
              <div class="relative rounded-2xl bg-[#0A101F]/80 ring-1 ring-white/10 backdrop-blur">
                <div class="absolute -top-px left-20 right-11 h-px bg-gradient-to-r from-sky-300/0 via-sky-300/70 to-sky-300/0" />
                <div class="absolute -bottom-px left-11 right-20 h-px bg-gradient-to-r from-blue-400/0 via-blue-400 to-blue-400/0" />
                <div class="pl-4 pt-4">
                  <TrafficLightsIcon class="h-2.5 w-auto stroke-slate-500/30" />
                  <div class="mt-4 flex space-x-2 text-xs">
                    {tabs.map((tab) => (
                      <div
                        key={tab.name}
                        class={`flex h-6 rounded-full ${tab.isActive                          
                            ? 'bg-gradient-to-r from-sky-400/30 via-sky-400 to-sky-400/30 p-px font-medium text-sky-300'
                            : 'text-slate-500'}`}
                      >
                        <div
                          class={`flex items-center rounded-full px-2.5 ${tab.isActive && 'bg-slate-800'}`}
                        >
                          {tab.name}
                        </div>
                      </div>
                    ))}
                  </div>
                  <div class="mt-6 flex items-start px-1 text-sm">
                    <div
                      aria-hidden="true"
                      class="select-none border-r border-slate-300/5 pr-4 font-mono text-slate-600"
                    >
                      {Array.from({
                        length: code.split('\n').length,
                      }).map((_, index) => (
                        <div key={index}>
                          {(index + 1).toString().padStart(2, '0')}
                          <br />
                        </div>
                      ))}
                    </div>
                    <Highlight
                      code={code}
                      language={codeLanguage}
                      theme={{ plain: {}, styles: [] }}
                    >                              
                    </Highlight>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}
